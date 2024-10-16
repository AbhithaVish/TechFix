<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="TechFix.orders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order History - TechFix</title>
    <link href="adminStyles.css" rel="stylesheet" />
    <style>
        .orders-container {
            width: 80%;
            margin: 50px auto;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        table, th, td {
            border: 1px solid #ccc;
        }

        th, td {
            padding: 15px;
            text-align: center;
        }

        th {
            background-color: #f4f4f4;
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
                            <li><asp:Button ID="btnAddProducts" runat="server" class="nav__link" Text="Add Products" /></li>
                            <li><asp:Button ID="btnviewProducts" runat="server" class="nav__link" Text="View Products"/></li>
                            <li><asp:Button ID="btnOrders" runat="server" class="nav__link" Text="Orders" /></li>
                            <li><asp:Button ID="btnProfile" runat="server" class="nav__link" Text="Profile" /></li>
                            <li><asp:Button ID="btnCus" runat="server" class="nav__link" Text="Customers" /></li>
                            <li><a href="welcome.php" class="login" id="loginbutton">Log Out</a></li>
                        </ul>
                    </div>
                </nav>
            </header>
            <div>
                <asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="orders-container">
            <br />
            <br />
            <br />
            <h1>Your Orders</h1>
            <asp:Literal ID="ordersMessage" runat="server" Text=""></asp:Literal>

            <asp:Repeater ID="ordersRepeater" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>Order ID</th>
                                <th>Product Name</th>
                                <th>Quantity</th>
                                <th>Price</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("OrderId") %></td>
                        <td><%# Eval("productName") %></td>
                        <td><%# Eval("productQty") %></td>
                        <td><%# Eval("price") %></td>
                        <td><%# Eval("status") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
