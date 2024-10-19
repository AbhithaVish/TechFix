<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CusOrders.aspx.cs" Inherits="TechFix.Admin.CusOrders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Orders</title>
    <link href="../CSS/NavBar.css" rel="stylesheet" />
    <style>


/* Content Section */
.content {
    flex-grow: 1;
    padding: 20px;
}

h1 {
    margin-bottom: 20px;
    color: #333;
}

/* Order Container and Item */
.order-container {
    background-color: #fff;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    
    /* Add flexbox to display items in rows */
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between; /* Ensure items are spaced evenly */
}

.order-item {
    background-color: #f9f9f9;
    border: 1px solid #ddd;
    border-radius: 5px;
    padding: 15px;
    margin-bottom: 20px;
    width: calc(50% - 10px); /* Take up half the row, with margin between */
    box-sizing: border-box;
}

.order-item table {
    width: 100%;
}

.order-item table td {
    padding: 5px 10px;
}

hr {
    border: none;
    border-top: 1px solid #ddd;
}

/* Button Styling */
.update-button, .edit-button, .delete-button {
    padding: 10px 15px;
    border: none;
    color: #fff;
    font-size: 14px;
    cursor: pointer;
    margin-right: 10px;
}

.update-button {
    background-color: #5cb85c;
}

.edit-button {
    background-color: #5bc0de;
}

.delete-button {
    background-color: #d9534f;
}

.update-button:hover {
    background-color: #4cae4c;
}

.edit-button:hover {
    background-color: #46b8da;
}

.delete-button:hover {
    background-color: #c9302c;
}

/* Message and Error Styling */
.message, .error-message {
    color: red;
    font-weight: bold;
    margin-top: 10px;
}

/* Responsive Design */
@media (max-width: 768px) {
    .container {
        flex-direction: column;
    }

    .sidebar {
        width: 100%;
    }

    .sidebar__link {
        font-size: 14px;
    }

    .content {
        padding: 10px;
    }

    /* Stack the items vertically on smaller screens */
    .order-item {
        width: 100%; /* Full width on mobile */
        margin-bottom: 20px;
    }
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
                <div class="order-container">
                    <asp:Label ID="ordersMessage" runat="server" CssClass="message"></asp:Label>

                    <asp:Repeater ID="orderList" runat="server" OnItemCommand="orderList_ItemCommand">
                        <ItemTemplate>
                            <div class="order-item">
                                <table>
                                    <tr>
                                        <td><strong>Order Id:</strong></td>
                                        <td><asp:Label ID="lblOrderId" runat="server" Text='<%# Eval("OrderId") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><strong>Order Line Id:</strong></td>
                                        <td><asp:Label ID="lblOrderLineId" runat="server" Text='<%# Eval("OrderLine_Id") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td><strong>Product Name:</strong></td>
                                        <td><%# Eval("productName") %></td>
                                    </tr>
                                    <tr>
                                        <td><strong>Quantity:</strong></td>
                                        <td><%# Eval("productQty") %></td>
                                    </tr>
                                    <tr>
                                        <td><strong>Price:</strong></td>
                                        <td>Rs. <%# Eval("price", "{0:F2}") %></td>
                                    </tr>
                                    <tr>
                                        <td><strong>Supplier:</strong></td>
                                        <td><%# Eval("username") %></td>
                                    </tr>
                                    <tr>
                                        <td><strong>Status:</strong></td>
                                        <td>
                                            <asp:DropDownList ID="ddlStatus" runat="server">
                                                <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                                <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                                <asp:ListItem Text="Canceled" Value="Canceled"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>

                                <asp:Button ID="btnUpdateStatus" runat="server" Text="Update Status"
                                    CommandName="UpdateStatus" 
                                    CommandArgument='<%# Eval("OrderLine_Id").ToString() %>'
                                    CssClass="update-button" />
                                <asp:Button ID="btnEdit" runat="server" Text="Edit"
                                    CommandName="Edit" 
                                    CommandArgument='<%# Eval("OrderId").ToString() %>' 
                                    CssClass="edit-button" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete"
                                    CommandName="Delete" 
                                    CommandArgument='<%# Eval("OrderId").ToString() %>' 
                                    CssClass="delete-button" />
                            </div>
                            <hr />
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:Label ID="lblText" runat="server" CssClass="error-message"></asp:Label>
                </div>
            </section>
        </div>
    </form>
</body>
</html>
