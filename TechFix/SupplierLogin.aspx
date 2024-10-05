<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierLogin.aspx.cs" Inherits="TechFix.SupplierLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supplier Login</title>
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
    <h1>Log In</h1>
    <table>
        <asp:Label ID="lbltext" runat="server" Text="" ForeColor="Red" ></asp:Label>
        <tr class="form-group">
            <td class="username">Username : </td>
            <td id="username"> <asp:TextBox ID="txtusername" runat="server" Width="448px"></asp:TextBox></td>
        </tr>
        <tr class="form-group">
            <td class="password">Password : </td>
            <td id="password"> <asp:TextBox ID="txtpassword" runat="server" Width="448px"></asp:TextBox></td>
        </tr>
    </table>
    <div >
        <asp:Button ID="btnlogin" runat="server" Text="Log in" class="btn" OnClick="btnlogin_Click" />
    </div>
    
</div>
    </form>
</body>
</html>
