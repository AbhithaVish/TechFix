<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminViewProducts.aspx.cs" Inherits="TechFix.adminViewProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Products - Admin</title>
    <link href="adminStyles.css" rel="stylesheet" />
    <link href="viewproducts.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="product-container">
            <h1>Products</h1>
            <asp:Repeater ID="productRepeater" runat="server" OnItemCommand="productRepeater_ItemCommand">
                <ItemTemplate>
                    <div class="product-item">
                        <div>
                            <h3>Product Name: <%# Eval("productName") %></h3>
                            <p>Product Description: <%# Eval("productDesc") %></p> 
                            <p>Price: $<%# Eval("productPrice", "{0:F2}") %></p> 
                            <p>Quantity Available: <%# Eval("productQty") %></p>
                            <p>Category ID: <%# Eval("categoryId") %></p>
                            <p>Added By (Supplier): <%# Eval("username") %></p>
                            <p>Product ID: <%# Eval("productID") %></p> 
                        </div>
                        <div class="product-actions">
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" 
                                        CommandArgument='<%# Eval("productID") %>' CommandName="AddToCart" 
                                        CssClass="add-to-cart" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:Button ID="btnViewCart" runat="server" Text="View Cart" CssClass="view-cart" OnClick="btnViewCart_Click" />
            <asp:Label ID="lblText" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
