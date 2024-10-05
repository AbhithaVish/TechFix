<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplerHome.aspx.cs" Inherits="TechFix.SupplerHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnadd" runat="server" Text="Add products" OnClick="btnadd_Click" /><br />
            <asp:Button ID="btnview" runat="server" Text="View Products" /><br />
            <asp:Button ID="btnedit" runat="server" Text="Edit " /><br />
            <asp:Button ID="btndelete" runat="server" Text="Delete" /><br />
            <asp:Button ID="btnorders" runat="server" Text="Orders" /><br />
            <asp:Button ID="btnstocks" runat="server" Text="Stocks" /><br />

        </div>
    </form>
</body>
</html>
