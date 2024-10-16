<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="TechFix.cart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart - TechFix</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa; /* Light background color */
            margin: 0;
            padding: 20px;
        }

        .cart-container {
            max-width: 800px;
            margin: auto;
            background: #fff; /* White background for the cart */
            border-radius: 8px; /* Rounded corners */
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1); /* Subtle shadow for depth */
            padding: 20px; /* Inner padding */
        }

        h1 {
            text-align: center; /* Center the heading */
            color: #333; /* Dark color for text */
        }

        table {
            width: 100%;
            border-collapse: collapse; /* Collapse borders for a clean look */
            margin-top: 20px; /* Space above the table */
        }

        th, td {
            padding: 10px; /* Padding inside cells */
            text-align: left; /* Left align text */
        }

        th {
            background-color: #007bff; /* Bootstrap primary color */
            color: #fff; /* White text for headers */
        }

        tr:nth-child(even) {
            background-color: #f2f2f2; /* Alternate row color */
        }

        tr:hover {
            background-color: #e9ecef; /* Highlight row on hover */
        }

        .remove-btn {
            background-color: #dc3545; /* Bootstrap danger color */
            color: white; /* White text */
            border: none; /* Remove border */
            border-radius: 5px; /* Rounded corners */
            padding: 5px 10px; /* Padding for buttons */
            cursor: pointer; /* Pointer cursor for buttons */
        }

        .remove-btn:hover {
            background-color: #c82333; /* Darker red on hover */
        }

        .checkout-btn {
            background-color: #28a745; /* Bootstrap success color */
            color: white; /* White text */
            border: none; /* Remove border */
            border-radius: 5px; /* Rounded corners */
            padding: 10px 15px; /* Padding for buttons */
            cursor: pointer; /* Pointer cursor for buttons */
            margin-top: 20px; /* Space above the button */
            display: block; /* Make it a block element */
            width: 100%; /* Full width */
        }

        .checkout-btn:hover {
            background-color: #218838; /* Darker green on hover */
        }

        .total-section {
            text-align: right; /* Align total price to the right */
            font-weight: bold; /* Bold text for total price */
            margin-top: 20px; /* Space above the total section */
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
    </form>
</body>
</html>
