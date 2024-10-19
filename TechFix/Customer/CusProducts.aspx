<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CusProducts.aspx.cs" Inherits="TechFix.Customer.CusProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer View Products</title>
    <link href="../CSS/CustomerNav.css" rel="stylesheet" />
    <link href="../CSS/ProductView.css" rel="stylesheet" />
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
                <asp:Label ID="lblWelcome" runat="server" Text="Welcome, Admin!" CssClass="welcome-label"></asp:Label>
                <div>
       <div class="product-container">
          <h1>Products</h1>

          <asp:DataList ID="productList" runat="server" RepeatColumns="2" CellSpacing="10" 
              OnItemCommand="productList_ItemCommand">

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
          <asp:Button ID="btnViewCart" runat="server" Text="View Cart" CssClass="view-cart" OnClick="btnViewCart_Click" />
          <asp:Label ID="lblText" runat="server" Text="" ForeColor="Red"></asp:Label>
      </div>
                                   </div>
                </div>
            </section>
        </div>
    </form>
</body>
</html>
