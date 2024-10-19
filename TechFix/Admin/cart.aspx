<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="TechFix.cart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart - TechFix</title>
    <link href="../CSS/NavBar.css" rel="stylesheet" />
    <link href="../CSS/CartStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
                <aside class="sidebar">
                    <ul class="sidebar__list">
                         <li><asp:Button ID="btndash" runat="server" CssClass="sidebar__link" Text="Dashboard" OnClick="btndash_Click" /></li>
 <li><asp:Button ID="Button1" runat="server" CssClass="sidebar__link" Text="Categories" OnClick="Button1_Click" /></li>
 <li><asp:Button ID="btnSup" runat="server" CssClass="sidebar__link" Text="Suppliers" OnClick="btnSup_Click" /></li>
 <li><asp:Button ID="btnCUs" runat="server" CssClass="sidebar__link" Text="Customers" OnClick="btnCUs_Click" /></li>
 <li><asp:Button ID="Button3" runat="server" CssClass="sidebar__link" Text="Supplier Products" OnClick="Button3_Click"  /></li>
 <li><asp:Button ID="Button5" runat="server" CssClass="sidebar__link" Text="Customer Products Add" OnClick="Button5_Click"  /></li>
 <li><asp:Button ID="btnStocks" runat="server" CssClass="sidebar__link" Text="Stock Management" OnClick="btnStocks_Click" /></li>
 <li><asp:Button ID="Button4" runat="server" CssClass="sidebar__link" Text="Customer Orders" OnClick="Button4_Click"  /></li>
 <li><asp:Button ID="btnOrders" runat="server" CssClass="sidebar__link" Text="Order Management" OnClick="btnOrders_Click" /></li>
 <li><asp:Button ID="Button2" runat="server" CssClass="sidebar__link" Text="Cart Management" OnClick="Button2_Click" /></li>
 <li><a href="../LoginForm.php" class="logout" id="loginbutton">Log Out</a></li>
                    </ul>
                </aside>

                <section class="content">
                    <div class="cart-container">
    <h1>Your Cart</h1>
    <asp:Literal ID="cartMessage" runat="server" Text=""></asp:Literal>

    <asp:Repeater ID="cartRepeater" runat="server" OnItemCommand="cartRepeater_ItemCommand">
        <HeaderTemplate>
            <table>
                <thead>
                    <tr>
                        <th>Product Name</th>
                        <th>Supplier</th>
                        <th>Price</th>
                        <th>Quantity</th>
                        <th>Total</th>
                        <th>Remove</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("productName") %></td>
                <td><%# Eval("username") %></td>
                <td>Rs.<%# Eval("productPrice", "{0:F2}") %></td>
                <td>
                    <asp:TextBox ID="quantityTextBox" runat="server" Text='<%# Eval("Quantity") %>' Width="50px" />
                    <asp:Button ID="updateBtn" runat="server" Text="Update" CommandArgument='<%# Eval("productName") %>' CommandName="Update" />
                </td>
                <td>Rs.<%# Eval("TotalPrice", "{0:F2}") %></td>
                <td>
                    <asp:Button ID="removeBtn" runat="server" Text="Remove" CommandArgument='<%# Eval("productName") %>' CommandName="Remove" CssClass="remove-btn" />
                </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <div class="total-section">
        <asp:Literal ID="totalPriceLiteral" runat="server" Text="Total Price: Rs.0.00"></asp:Literal>
        <asp:Button ID="checkoutBtn" runat="server" Text="Proceed to Checkout" OnClick="Checkout_Click" CssClass="checkout-btn" />
    </div>

    <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
</div>
                </section>
            </div>
        
    </form>
</body>
</html>
