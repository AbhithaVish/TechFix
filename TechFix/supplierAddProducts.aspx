<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplierProductAddWebForm.aspx.cs" Inherits="ClientWebApplication.supplierProductAddWebForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Management</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/products.css"/>
    <link href="ProductAdd.css" rel="stylesheet" />
    <style>
        body {
            font-family: 'Roboto', sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f9f9f9;
        }

        h1 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }

        .message-label {
            text-align: center;
            color: green;
            font-size: 18px;
            margin-bottom: 10px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
        }

        .form-control:focus {
            border-color: #007bff;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
            outline: none;
        }

        .button-container {
            text-align: center;
        }

        .btn-submit {
            background: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            transition: background 0.3s;
        }

        .btn-submit:hover {
            background: #0056b3;
        }

        label {
            font-weight: bold;
            color: #333;
        }
    </style>
</head>
<body>
    <h1>Add New Product</h1>
    <div class="message-label">
        <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
    </div>
    <form id="form1" runat="server">
        <div class="form-group">
            <asp:Label ID="lblProdName" runat="server" Text="Product Name"></asp:Label>
            <asp:TextBox ID="txtProdName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdPrice" runat="server" Text="Product Price"></asp:Label>
            <asp:TextBox ID="txtProdPrice" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdQty" runat="server" Text="Product Quantity"></asp:Label>
            <asp:TextBox ID="txtProdQty" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdDesc" runat="server" Text="Product Description"></asp:Label>
            <asp:TextBox ID="txtProdDesc" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="dlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="button-container">
            <asp:Button ID="addBtn" runat="server" Text="Add Product" OnClick="addBtn_Click" CssClass="btn-submit" />
        </div>
    </form>

</body>
</html>
