<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quotation.aspx.cs" Inherits="TechFix.Customer.Quotation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Your Quotation</title>
    <link href="../CSS/CustomerNav.css" rel="stylesheet" />
    <link href="../CSS/CartStyle.css" rel="stylesheet" />
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

<li>
     <asp:Button ID="btnLogout" runat="server" class="login" Text="Log Out" OnClick="btnLogout_Click" />
 </li>
                        </ul>
                    </div>
                </nav>
            </header>

            <section class="content">
                <div class="cart-container">
                    <h1>Your Quotation</h1>
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
