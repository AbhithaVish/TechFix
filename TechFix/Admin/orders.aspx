<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="TechFix.orders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order History - TechFix</title>
    <link href="../CSS/NavBar.css" rel="stylesheet" />
    <link href="../CSS/OrdersStyle.css" rel="stylesheet" />
    <style>
        /* General styles for the page */
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f4f4f4;
}

.content {
    flex-grow: 1; /* Take up remaining space */
    padding: 20px;
}

.orders-container {
    background-color: white;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
}

    /* Heading styles */
    .orders-container h1 {
        font-size: 28px;
        color: #2c3e50;
        margin-bottom: 20px;
    }

    /* Orders Table Styles */
    .orders-container table {
        width: 100%;
        border-collapse: collapse;
        margin-bottom: 20px;
        font-size: 16px;
    }

    .orders-container th, .orders-container td {
        padding: 12px 15px;
        text-align: left;
        border-bottom: 1px solid #ddd;
    }

    .orders-container th {
        background-color: #34495e;
        color: white;
        text-transform: uppercase;
        font-weight: 600;
    }

    .orders-container tr:nth-child(even) {
        background-color: #f9f9f9;
    }

    .orders-container tr:hover {
        background-color: #f1f1f1;
    }

    .orders-container td {
        color: #333;
    }

        /* Status column styling */
        .orders-container td:nth-child(5) {
            font-weight: bold;
        }

            /* Status color coding */
            .orders-container td:nth-child(5):contains("Delivered") {
                color: green;
            }

            .orders-container td:nth-child(5):contains("Pending") {
                color: orange;
            }

            .orders-container td:nth-child(5):contains("Cancelled") {
                color: red;
            }

    </style>
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
         <div>
             <div class="orders-container">
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
         </div>
        
     </section>
 </div>
    </form>
</body>
</html>
