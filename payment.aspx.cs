using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CompuTop.Core.Crypto;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace ctS2SASPNET
{
    public partial class payment : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument xmlFile = new XmlDocument();
            XmlElement xmlElement = xmlFile.DocumentElement;
            xmlFile.Load(MapPath("ini.xml"));

            // !!! security !!! these values are normally extracted from a database
            // via e-mail from computop support
            string merchantID = xmlFile.DocumentElement.SelectSingleNode("payment/values/merchantID").InnerText;
            // via phone from comutop support - 16 digits
            string password = xmlFile.DocumentElement.SelectSingleNode("payment/values/password").InnerText;

            string[] payTypes    = new string[3];
            payTypes[0] = xmlFile.DocumentElement.SelectSingleNode("input/paytypes/pt0/name").InnerText;      //not yet implemented
            payTypes[1] = xmlFile.DocumentElement.SelectSingleNode("input/paytypes/pt1/name").InnerText;
            payTypes[2] = xmlFile.DocumentElement.SelectSingleNode("input/paytypes/pt2/name").InnerText; ;

            string[] URLs    = new string[3];
            URLs[0] = xmlFile.DocumentElement.SelectSingleNode("input/paytypes/pt0/url").InnerText; ;                                   //not yet implemented
            URLs[1] = xmlFile.DocumentElement.SelectSingleNode("input/paytypes/pt1/url").InnerText; ;
            URLs[2] = xmlFile.DocumentElement.SelectSingleNode("input/paytypes/pt2/url").InnerText; ;

            
            string encryptedData     = string.Empty;
            string data              = string.Empty;
            string requestURL        = string.Empty;
            string queryData         = string.Empty;
            int dataLen              = 0;
            string merchant          = @"MerchantID=" + merchantID;
            string amount            = @"Amount=" + Request.Form["tbAmount"];
            string transID           = @"TransID=" + Request.Form["tbTransID"];
            string currency          = @"Currency=" + Request.Form["tbCurrency"];

            data = merchant + "&" + transID + "&" + amount + "&" + currency + "&";

            switch (Request.Form["rbPayment"])
            {
                case "CC":
                    data += "CCNr=" + Request.Form["tbCCNr"] + "&" +
                                "CCCVC=" + Request.Form["tbCVC"] + "&" +
                                "CCExpiry=" + Request.Form["tbCCExpiry"] + "&" +
                                "CCBrand=" + Request.Form["tbCCBrand"];
                    requestURL = URLs[1];
                    break;
                case "EDD":
                    data += "AccOwner=" + Request.Form["tbAccOwner"] + "&" +
                                "AccNr=" + Request.Form["tbAccNr"] + "&" + 
                                "AccBank=" + Request.Form["tbBank"] + "&" +
                                "AccIBAN=" + Request.Form["tbIBAN"];
                    requestURL = URLs[2];
                    break;
            }

            CompuTop.Core.Crypto.HexCoding hexcoding = new HexCoding();
            CompuTop.Core.Crypto.BlowFish blowfish = new BlowFish(password, hexcoding);
            encryptedData = blowfish.EncryptECB(data);
            
            dataLen = data.Length;
            queryData = @"MerchantID=" + merchantID + "&Len=" + dataLen + "&Data=" + encryptedData;

            SendWebRequest(requestURL, queryData, dataLen);
        }

        private void SendWebRequest(string requestURL, string queryData, int dataLen)
        {
            int ContentLen = queryData.Length;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestURL);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = ContentLen;
            webRequest.Method = "POST";

            StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream());

            try
            {
                streamWriter.Write(queryData);
                streamWriter.Flush();
            }
            finally
            {
                streamWriter.Close();
            }

            GetWebResponse(webRequest);
        }

        private void GetWebResponse(HttpWebRequest webRequest)
        {
            string encryptedData = string.Empty;
            

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            try
            {
                using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                {
                    encryptedData = streamReader.ReadToEnd();
                    ShowResponse(encryptedData);
                }
            }
            catch(ApplicationException e)
            {
               Response.Write(@"<table border=1><tr><td><table border=0 cellpadding=4><tr><th colspan=2><u>Information</u></th></tr><tr><td>Status: </td><td>" + e.ToString() + "</td></tr>" +
                   "</table></td></tr></table></center></body></html>");
            }
        }

        private void ShowResponse(string encryptedData)
        {
            XmlDocument xmlFile = new XmlDocument();
            XmlElement xmlElement = xmlFile.DocumentElement;
            xmlFile.Load(MapPath("ini.xml"));

            Regex LenInformation = new Regex(@"(?<=Len=)(\d+)");
            Regex DataInformation = new Regex(@"(?<=Data=)(\w+)");

            string password = xmlFile.DocumentElement.SelectSingleNode("payment/values/password").InnerText;

            CompuTop.Core.Crypto.HexCoding hexcoding = new HexCoding();
            CompuTop.Core.Crypto.BlowFish blowfish = new BlowFish(password, hexcoding);

            string[] decryptedQueryPairs;
            string[] decryptedQueryContent;
            string encryptData = encryptedData;

            // get Len from Response
            int iResponseLen = int.Parse(LenInformation.Match(encryptedData).Value);

            // get Data from Response
            encryptData = DataInformation.Match(encryptedData).Value;

            // decrypt querystring from response + split into array
            decryptedQueryPairs = blowfish.DecryptECB(encryptData, iResponseLen).Split('&');



            // split key-value-pairs into dictionary
            for (int i = 0; i < decryptedQueryPairs.Length; i++)
            {
                decryptedQueryContent = decryptedQueryPairs[i].ToString().Split('=');
             
                // show response
                lblStatus.Text += decryptedQueryContent[0] + ": " + decryptedQueryContent[1] + "<br>";
            }
        }
    }
}
