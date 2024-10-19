<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierViewProducts.aspx.cs" Inherits="TechFix.SupplierViewProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Products - Supplier</title>
    <link href="../CSS/SupplierStyle.css" rel="stylesheet" />
    <link href="../CSS/ManageProducts.css" rel="stylesheet" />
    <style>
        .content{
            margin-top:200px;
        }
    </style>
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
                                                  <h1>Manage Products</h1>
                <asp:GridView ID="ProductsGridView" runat="server" CssClass="gridview-container" AutoGenerateColumns="False" DataKeyNames="productID"
                              OnRowEditing="ProductsGridView_RowEditing"
                              OnRowUpdating="ProductsGridView_RowUpdating"
                              OnRowDeleting="ProductsGridView_RowDeleting"
                              OnRowCancelingEdit="ProductsGridView_RowCancelingEdit">
                    <Columns>
                        <asp:BoundField DataField="productID" HeaderText="Product ID" ReadOnly="True" />
        
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("productName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("productName") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField HeaderText="Product Price">
                            <ItemTemplate>
                                <asp:Label ID="lblProductPrice" runat="server" Text='<%# Eval("productPrice") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProductPrice" runat="server" Text='<%# Bind("productPrice") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Product Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblProductQty" runat="server" Text='<%# Eval("productQty") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProductQty" runat="server" Text='<%# Bind("productQty") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Product Description">
                            <ItemTemplate>
                                <asp:Label ID="lblProductDesc" runat="server" Text='<%# Eval("productDesc") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProductDesc" runat="server" Text='<%# Bind("productDesc") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" Text="Edit" CssClass="edit-link"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" Text="Update" CssClass="edit-link"></asp:LinkButton>
                                <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="cancel-link"></asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>

                       <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" CssClass="delete-link">
                                Delete
                            </asp:LinkButton>
                        </ItemTemplate>
</asp:TemplateField>

                    </Columns>
                </asp:GridView>
             </div>
    </div>
    </form>
</body>
</html>
