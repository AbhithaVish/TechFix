<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplierAddProducts.aspx.cs" Inherits="TechFix.supplierAddProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Products - Supplier</title>
    <link href="adminStyles.css" rel="stylesheet" />
    <style>
        body, h1, form, input, table, ul, li {
            padding: 0;
            box-sizing: border-box;
        }

        html {
            margin-top: 200px;
            overflow-y: scroll;
        }

        .product-container {
            width: 60%;
            max-width: 600px;
            margin: 20px auto;
            padding: 20px;
            background: #474747;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            border-radius: 8px;
        }

        .product-text-topic {
            text-align: center;
            color: #ffffff;
            margin-bottom: 20px;
        }

        form {
            display: flex;
            flex-direction: column;
        }

        .product-mb-3 {
            margin-bottom: 15px;
        }

        .product-mb-3 label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #fff;
        }

        .product-mb-3 input, .product-mb-3 select {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

         .product-btn-add {
            background: #007bff;
            color: #fff;
            padding: 10px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

         .product-btn-add:hover {
            background: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navigation Bar -->
        <div>
            <header class="header">
                <nav class="nav container">
                    <div class="nav__menu">
                        <ul class="nav__list">
                            <li><asp:Button ID="btnAddProducts" runat="server" class="nav__link" Text="Add Products" /></li>
                            <li><asp:Button ID="btnviewProducts" runat="server" class="nav__link" Text="View Products" /></li>
                            <li><asp:Button ID="btnOrders" runat="server" class="nav__link" Text="Orders" /></li>
                            <li><asp:Button ID="btnProfile" runat="server" class="nav__link" Text="Profile" /></li>
                            <li><asp:Button ID="btnCus" runat="server" class="nav__link" Text="Customers" /></li>
                            <li><a href="welcome.php" class="login">Log Out</a></li>
                        </ul>
                    </div>
                </nav>
            </header>
        </div>

        <!-- Add Product Form -->
        <div class="product-container">
            <h2 class="product-text-topic">Add Products</h2>
            <asp:Label ID="lblText" runat="server" Text="Label"></asp:Label>
            <table>
                <tr class="product-mb-3">
                    <td><label for="txtitemId">Item ID:</label></td>
                    <td><asp:TextBox ID="txtitemId" runat="server" CssClass="product-form-control"></asp:TextBox></td>
                </tr>
                <tr class="product-mb-3">
                    <td><label for="txtProductName">Product Name:</label></td>
                    <td><asp:TextBox ID="txtProductName" runat="server" CssClass="product-form-control"></asp:TextBox></td>
                </tr>
                <tr class="product-mb-3">
                    <td><label for="txtDescription">Product Description:</label></td>
                    <td><asp:TextBox ID="txtDescription" runat="server" CssClass="product-form-control"></asp:TextBox></td>
                </tr>
                <tr class="product-mb-3">
                    <td><label for="txtProductPrice">Product Price:</label></td>
                    <td><asp:TextBox ID="txtProductPrice" runat="server" CssClass="product-form-control"></asp:TextBox></td>
                </tr>
                <tr class="product-mb-3">
                    <td><label for="txtQuantity">Product Quantity:</label></td>
                    <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="product-form-control"></asp:TextBox></td>
                </tr>
                <tr class="product-mb-3">
                    <td><label for="dlcategory">Category:</label></td>
                    <td><asp:DropDownList ID="dlcategory" runat="server" CssClass="product-form-control"></asp:DropDownList></td>
                </tr>
                <tr class="product-mb-3">
                    <td><label for="txtwarranty">Warranty:</label></td>
                    <td><asp:TextBox ID="txtwarranty" runat="server" CssClass="product-form-control"></asp:TextBox></td>
                </tr>
                <tr class="product-mb-3">
                    <td></td>
                    <td><asp:Button ID="btnAddProduct" runat="server" Text="Add Product" CssClass="product-btn-add" OnClick="btnAddProduct_Click" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
