<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Suppliers.aspx.cs" Inherits="TechFix.Admin.Suppliers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Suppliers</title>
    <link href="../CSS/NavBar.css" rel="stylesheet" />
    <link rel="stylesheet" href="../CSS/manageProducts.css" />
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
                <h1>View Suppliers</h1>
                <asp:GridView ID="SuppliersGridView" runat="server" CssClass="gridview-container" AutoGenerateColumns="False" DataKeyNames="username"
                    OnRowEditing="SuppliersGridView_RowEditing"
                    OnRowUpdating="SuppliersGridView_RowUpdating"
                    OnRowDeleting="SuppliersGridView_RowDeleting"
                    OnRowCancelingEdit="SuppliersGridView_RowCancelingEdit">
                    <Columns>
                        <asp:BoundField DataField="username" HeaderText="Username" ReadOnly="True" />
                        
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:CommandField ShowEditButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </section>
        </div>
    </form>
</body>
</html>
