<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplierAddProducts.aspx.cs" Inherits="TechFix.supplierAddProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <h1>Add Products</h1>
            <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
            <table>
                <tr>
                    <td>Item ID:</td>
                    <td><asp:TextBox ID="txtitemId" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Product Name:</td>
                    <td><asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Product Description:</td>
                    <td><asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Product Price:</td>
                    <td><asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Product Quantity:</td>
                    <td><asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Category:</td>
                    <td><asp:DropDownList ID="dlcategory" runat="server"></asp:DropDownList></td>
                </tr>   
                <tr>
                    <td>Warrenty:</td>
                    <td><asp:TextBox ID="txtwarranty" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
