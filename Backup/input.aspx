<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="input.aspx.cs" Inherits="ctS2SASPNET._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>input.aspx</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" ColumnSpan="6" HorizontalAlign="Center">
                <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblTransID" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbTransID" runat="server" TabIndex="1"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblCC" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <input id="rbCC" value="CC" name="rbPayment" checked="checked" type="radio" tabindex="6" />
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblEDD" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <input id="rbEDD" value="EDD" name="rbPayment" type="radio" tabindex="11" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbAmount" runat="server" TabIndex="2"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblCCNr" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbCCNr" runat="server" TabIndex="7"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblAccOwner" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbAccOwner" runat="server" TabIndex="12"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblCurrency" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbCurrency" runat="server" MaxLength="3" Width="30" TabIndex="3"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblCVC" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbCVC" runat="server" MaxLength="3" Width="30" TabIndex="8"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblAccNr" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbAccNr" runat="server" TabIndex="13"></asp:TextBox>
                </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblOrderDesc" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbOrderDesc" runat="server" TabIndex="4"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblCCExpiry" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbCCExpiry" runat="server" TabIndex="9"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblBank" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbBank" runat="server" TabIndex="15"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblUserdata" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbUserdata" runat="server" TabIndex="5"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblCCBrand" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbCCBrand" runat="server" TabIndex="10"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell runat="server" HorizontalAlign="Right">
                <asp:Label ID="lblIBAN" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:TextBox ID="tbIBAN" runat="server" TabIndex="16"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" ColumnSpan="6">
                <asp:Button ID="btnSend" runat="server" Text="" PostBackUrl="payment.aspx" />
                </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        <asp:TextBox ID="tbMerchantID" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="tbPassword" runat="server" Visible="False"></asp:TextBox>
    </div>
    </form>
</body>
</html>
