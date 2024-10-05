<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcategories.aspx.cs" Inherits="TechFix.addcategories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add categories</h1>
            <asp:Label ID="lbltext" runat="server" Text="" ForeColor="Green" ></asp:Label>
            <table>
                <tr>
                    <td>Category ID: </td>
                    <td><asp:TextBox ID="txtid" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Category Name: </td>
                    <td><asp:TextBox ID="txtcategory" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td> <asp:Button ID="btnsubmit" runat="server" Text="Save" OnClick="btnsubmit_Click" style="height: 26px" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
