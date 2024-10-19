<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupOrders.aspx.cs" Inherits="TechFix.SupOrders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supplier Orders</title>
    <link href="../CSS/SupplierStyle.css" rel="stylesheet" />
    <link href="../CSS/ProductView.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
            <div>
             <header class="header">
                 <nav class="nav container">
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
                  <div>
                      <div class="order-container">
    <h1>Orders</h1>
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
                    CommandArgument='<%# Eval("OrderId").ToString() %>'
                    CssClass="update-button" />
            </div>
            <hr />
        </ItemTemplate>
    </asp:Repeater>

    <asp:Label ID="lblText" runat="server" CssClass="error-message"></asp:Label>
</div>
                  </div>
         </div>
    </form>
</body>
</html>
