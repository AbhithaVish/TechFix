<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminViewProducts.aspx.cs" Inherits="TechFix.adminViewProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Products - Admin</title>
    <link href="ProductView.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
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
                                <td><asp:TextBox ID="txtProductQty" runat="server" Text='<%# Eval("productQty") %>' ReadOnly="true" CssClass="product-input" /></td>
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
                        </div>
                    </div>
                    <hr />
                </ItemTemplate>
            </asp:DataList>

            <asp:Button ID="btnViewCart" runat="server" Text="View Cart" CssClass="view-cart" OnClick="btnViewCart_Click" />
            <asp:Label ID="lblText" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
