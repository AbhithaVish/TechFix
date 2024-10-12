<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplierProductAddWebForm.aspx.cs" Inherits="ClientWebApplication.supplierProductAddWebForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Management</title>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/products.css"/>
    <style>
        body, h1, form, input, button {
    padding: 0;
    box-sizing: border-box;
}

html {
    margin-top: 200px;
}

.container-add {
    width: 80%;
    max-width: 800px;
    margin: 20px auto;
    padding: 20px;
    background: #fff;
    box-shadow: 0 0 10px rgba(0,0,0,0.1);
    border-radius: 8px;
}

h1 {
    text-align: center;
    color: #333;
    margin-bottom: 20px;
}

form {
    display: flex;
    flex-direction: column;
}

.table {
    width: 100%;
    margin-bottom: 20px;
}

td {
    padding: 10px 0;
    color: black; 
}

.form-group input, .form-group select {
    width: 100%;
    padding: 10px;
    font-size: 16px;
    border: 1px solid #ddd;
    border-radius: 4px;
}

.button-container {
    text-align: center;
}

button {
    background: #007bff;
    color: #fff;
    padding: 10px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    font-size: 16px;
    width: 150px;
}

button:hover {
    background: #0056b3;
}

label {
    font-weight: bold;
    color: black;  
}

.message-label {
    text-align: center;
    color: green;
    font-size: 18px;
    margin-bottom: 10px;
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
            <asp:TextBox ID="txtProdName" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdPrice" runat="server" Text="Product Price"></asp:Label>
            <asp:TextBox ID="txtProdPrice" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdQty" runat="server" Text="Product Quantity"></asp:Label>
            <asp:TextBox ID="txtProdQty" runat="server" TextMode="Number"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblProdDesc" runat="server" Text="Product Description"></asp:Label>
            <asp:TextBox ID="txtProdDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
            <asp:DropDownList ID="dlSupplier" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="dlCategory" runat="server"></asp:DropDownList>
        </div>

        <button type="submit" runat="server" onserverclick="addBtn_Click">Add Product</button>
    </form>

</body>
</html>
