using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.IO;

namespace ctS2SASPNET
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument xmlFile = new XmlDocument();
            XmlElement xmlElement = xmlFile.DocumentElement;
            xmlFile.Load(MapPath("ini.xml"));

            tbTransID.Text = xmlFile.DocumentElement.SelectSingleNode("input/values/transID").InnerText;
            tbAmount.Text = xmlFile.DocumentElement.SelectSingleNode("input/values/amount").InnerText;
            tbCurrency.Text = xmlFile.DocumentElement.SelectSingleNode("input/values/currency").InnerText;
            tbOrderDesc.Text = xmlFile.DocumentElement.SelectSingleNode("input/values/orderdesc").InnerText;
            tbUserdata.Text = xmlFile.DocumentElement.SelectSingleNode("input/values/userdata").InnerText; ;
       
            lblDescription.Text = "ASP - Server to Server";
            lblTransID.Text = "TransID";
            lblAmount.Text = "Amount";
            lblCurrency.Text = "Currency";
            lblOrderDesc.Text = "Order description";
            lblUserdata.Text = "Userdata";
            btnSend.Text = "Send Request";
            lblCCNr.Text = "CC Number";
            lblCVC.Text = "CVC";
            lblCCExpiry.Text = "CC Expiry";
            lblCCBrand.Text = "CC Brand";
            lblAccOwner.Text = "Account Owner";
            lblAccNr.Text = "Account Number";
            lblBank.Text = "Bank";
            lblIBAN.Text = "IBAN";
            lblCC.Text = "Creditcard Payment";
            lblEDD.Text = "Electronic Direct Debit";
        }
    }
}
