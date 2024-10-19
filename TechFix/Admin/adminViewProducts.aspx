<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminViewProducts.aspx.cs" Inherits="TechFix.adminViewProducts" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Products - Admin</title>
    <link href="../CSS/NavBar.css" rel="stylesheet" />
    <link href="../CSS/ProductView.css" rel="stylesheet" />
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
                    <asp:Label ID="lblWelcome" runat="server" Text="Welcome, Admin!" CssClass="welcome-label"></asp:Label>
                    <div>
                           <div class="product-container">
                                    <h1>Products</h1>

                                    <asp:DataList ID="productList" runat="server" RepeatColumns="1" CellSpacing="10" OnItemCommand="productList_ItemCommand">
                                        <ItemTemplate>
                                            <div class="product-item">
                                                <table>
                                                    <tr>
                                                        <td><label>Product Name:</label></td>
                                                        <td><asp:TextBox ID="txtProductName" runat="server" Text='<%# Eval("productName") %>' ReadOnly="true" CssClass="product-input" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><label>Product Description:</label></td>
                                                        <td><asp:TextBox ID="txtProductDesc" runat="server" Text='<%# Eval("productDesc") %>' ReadOnly="true" CssClass="product-input" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><label>Price:</label></td>
                                                        <td><asp:TextBox ID="txtProductPrice" runat="server" Text='<%# Eval("productPrice", "{0:F2}") %>' ReadOnly="true" CssClass="product-input" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><label>Quantity Available:</label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtProductQty" runat="server" Text='<%# Eval("productQty") %>' CssClass="product-input" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td><label>Category ID:</label></td>
                                                        <td><asp:TextBox ID="txtCategoryId" runat="server" Text='<%# Eval("categoryId") %>' ReadOnly="true" CssClass="product-input" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><label>Added By (Supplier):</label></td>
                                                        <td><asp:TextBox ID="txtUsername" runat="server" Text='<%# Eval("username") %>' ReadOnly="true" CssClass="product-input" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td><label>Product ID:</label></td>
                                                        <td><asp:TextBox ID="txtProductID" runat="server" Text='<%# Eval("productID") %>' ReadOnly="true" CssClass="product-input" /></td>
                                                    </tr>
                                                </table>
                                                <div class="product-actions">
                                                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart"
                                                                CommandArgument='<%# Eval("productID") %>' CommandName="AddToCart"
                                                                CssClass="add-to-cart" />
                                                    <asp:TextBox ID="txtqty" runat="server"></asp:TextBox>
                                                    <asp:Button ID="btnUpdateQty" runat="server" Text="Update Qty"
                                                                CommandArgument='<%# Eval("productID") %>' CommandName="UpdateQty"
                                                                CssClass="update-qty" />
                                                </div>
                                            </div>
                                            <hr />
                                        </ItemTemplate>
                                    </asp:DataList>

                                    <asp:Button ID="btnViewCart" runat="server" Text="View Cart" CssClass="view-cart" OnClick="btnViewCart_Click1"  />
                                    <asp:Label ID="lblText" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </div>
                    </div>
       
                </section>
            </div>
           
    </form>
</body>
</html>
