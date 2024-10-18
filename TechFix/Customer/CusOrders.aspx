<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CusOrders.aspx.cs" Inherits="TechFix.Customer.CusOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer - Orders</title>
    <link href="../CSS/CustomerNav.css" rel="stylesheet" />
    <link href="../CSS/ProductView.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <header class="header">
    <nav class="nav container">
        <div class="nav__menu">
            <ul class="nav__list">
                         <li><asp:Button ID="btndash" runat="server" class="nav__link" Text="Dashboard" OnClick="btndash_Click1"  /></li>
                         <li><asp:Button ID="btnProducts" runat="server" class="nav__link" Text="Products" OnClick="btnProducts_Click" /> </li>
                         <li><asp:Button ID="btnOrder" runat="server" class="nav__link" Text="Orders" OnClick="btnOrder_Click" /></li>
                         <li><asp:Button ID="btnCart" runat="server" class="nav__link" Text="Cart" OnClick="btnCart_Click" />  </li>
                         <li> <asp:Button ID="btncate" runat="server" class="nav__link" Text="Categories"   /></li>
                         <li> <asp:Button ID="btnPro" runat="server" class="nav__link" Text="Profile"  /> </li>

                <li> <a href="CusLogin.aspx" class="login" id="loginbutton">Log Out</a> </li>
            </ul>
        </div>
    </nav>
</header>
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
</div
    </form>
</body>
</html>
