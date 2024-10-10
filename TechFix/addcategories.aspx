<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcategories.aspx.cs" Inherits="TechFix.addcategories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Categories</title>
    <link href="adminStyles.css" rel="stylesheet" />
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

        table {
            width: 100%;
            margin-bottom: 20px;
        }

        td {
            padding: 10px 0;
            color: black; 
        }

        .form-group input {
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header class="header">
                <nav class="nav container">
                    <div class="nav__menu">
                        <ul class="nav__list">
                            <li><asp:Button ID="btndash" runat="server" class="nav__link" Text="Dashboard" /></li>
                            <li><asp:Button ID="btnOrder" runat="server" class="nav__link" Text="Order Management" /></li>
                            <li><asp:Button ID="btnStock" runat="server" class="nav__link" Text="Stock Management" /> </li>
                            <li> <asp:Button ID="btnCus" runat="server" class="nav__link" Text="Customer Management"  /> </li>
                            <li><asp:Button ID="btnsup" runat="server" class="nav__link" Text="Suppliers" />  </li>
                            <li> <asp:Button ID="btncate" runat="server" class="nav__link" Text="Categories" /></li>

                            <li> <a href="welcome.php" class="login" id="loginbutton">Log Out</a> </li>
                        </ul>
                    </div>
                </nav>
            </header>
        </div>
        <div class="container-add">
            <h1>Add Categories</h1>
            <asp:Label ID="lbltext" runat="server" Text="" ForeColor="Green"></asp:Label>
            <table>
                <tr>
                    <td>Category ID:</td>
                    <td><asp:TextBox ID="txtCategoryId" runat="server" class="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Category Name:</td>
                    <td><asp:TextBox ID="txtCategoryName" runat="server" class="form-control"></asp:TextBox></td>
                </tr>
            </table>
            <div class="button-container">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" style="height: 26px" />
            </div>
        </div>
    </form>
</body>
</html>
