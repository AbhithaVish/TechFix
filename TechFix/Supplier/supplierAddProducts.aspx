<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplierProductAddWebForm.aspx.cs" Inherits="ClientWebApplication.supplierProductAddWebForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Management</title>
    <link href="../CSS/SupplierStyle.css" rel="stylesheet" />
     <style>
        /* Form Container Styling */
        .form-container {
            max-width: 600px;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #f9f9f9;
        }

        .form-container h1 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }

        /* Message Label Styling */
        .message-label {
            margin-bottom: 20px;
            text-align: center;
        }

        .message-label asp:Label {
            font-size: 14px;
            color: red;
        }

        /* Form Group Styling */
        .form-group {
            margin-bottom: 15px;
        }

        .form-group asp:Label {
            display: block;
            font-size: 14px;
            margin-bottom: 5px;
            color: #333;
        }

        .form-group asp:TextBox,
        .form-group asp:DropDownList {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .form-group asp:TextBox[TextMode="MultiLine"] {
            height: 100px;
            resize: vertical;
        }

        /* Button Container Styling */
        .button-container {
            text-align: center;
            margin-top: 20px;
        }

        .button-container asp:Button {
            padding: 10px 20px;
            font-size: 16px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .button-container asp:Button:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="container">
            <!-- Navigation Bar at the top -->
            <header class="header">
                <nav class="nav">
                    <div class="nav__menu">
                        <ul class="nav__list">
                               <li><asp:Button ID="btnDashboard" runat="server" class="nav__link" Text="Dashboard" OnClick="btnDashboard_Click"/> </li>
 <li><asp:Button ID="btnAddProducts" runat="server" class="nav__link" Text="Add Products" OnClick="btnAddProducts_Click1"   /> </li>
 <li> <asp:Button ID="btnviewProducts" runat="server" class="nav__link" Text="View Products" OnClick="btnviewProducts_Click"   /></li>
 <li><asp:Button ID="btnOrders" runat="server" class="nav__link" Text="Orders" OnClick="btnOrders_Click"/>  </li>

<li>
    <asp:Button ID="btnLogout" runat="server" class="login" Text="Log Out" OnClick="btnLogout_Click"/>
</li>
                        </ul>
                    </div>
                </nav>
            </header>

            <!-- Form for adding new products -->
            <div class="form-container">
                <h1>Add New Product</h1>
                <div class="message-label">
                    <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
                </div>

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
    <asp:Label ID="lblProdDesc" runat="server" Text="Product Description"></asp:Label> <!-- Fixed the closing tag -->
    <asp:TextBox ID="txtProdDesc" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
</div>


                <div class="form-group">
                    <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
                    <asp:DropDownList ID="dlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="button-container">
                    <asp:Button ID="addBtn" runat="server" Text="Add Product" OnClick="addBtn_Click" CssClass="btn-submit" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
