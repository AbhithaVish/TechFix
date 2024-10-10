<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="TechFix.cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart - TechFix</title>
    <link href="adminStyles.css" rel="stylesheet" />
    <style>
        .cart-container {
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

        .total-section {
            display: flex;
            justify-content: space-between;
            margin-top: 30px;
        }

        .checkout-btn {
            background-color: #28a745;
            color: white;
            padding: 15px 30px;
            border: none;
            cursor: pointer;
            border-radius: 5px;
            font-size: 1.2rem;
        }

        .checkout-btn:hover {
            background-color: #218838;
        }

        .remove-btn {
            background-color: #dc3545;
            color: white;
            padding: 10px;
            border: none;
            cursor: pointer;
            border-radius: 5px;
        }

        .remove-btn:hover {
            background-color: #c82333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="cart-container">
            <h1>Your Cart</h1>
            <asp:Literal ID="cartMessage" runat="server" Text=""></asp:Literal>

            <asp:Repeater ID="cartRepeater" runat="server" OnItemCommand="cartRepeater_ItemCommand">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>Product Name</th>
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
                        <td>$<%# Eval("productPrice") %></td>
                        <td>
                            <asp:TextBox ID="quantityTextBox" runat="server" Text='<%# Eval("Quantity") %>' Width="50px" />
                            <asp:Button ID="updateBtn" runat="server" Text="Update" CommandArgument='<%# Eval("productID") %>' CommandName="Update" />
                        </td>
                        <td>$<%# Eval("TotalPrice") %></td>
                        <td>
                            <asp:Button ID="removeBtn" runat="server" Text="Remove" CommandArgument='<%# Eval("productID") %>' CommandName="Remove" CssClass="remove-btn" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

            <div class="total-section">
                <asp:Literal ID="totalPriceLiteral" runat="server"></asp:Literal>
                <asp:Button ID="checkoutBtn" runat="server" Text="Proceed to Checkout" OnClick="Checkout_Click" CssClass="checkout-btn" />
            </div>
        </div>
    </form>
</body>
</html>
