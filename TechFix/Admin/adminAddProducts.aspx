<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminAddProducts.aspx.cs" Inherits="TechFix.Admin.adminAddProducts" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Products</title>
    <link href="../CSS/NavBar.css" rel="stylesheet" />
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
    <label>Product Name:</label>
    <asp:TextBox ID="txtProdName" runat="server"></asp:TextBox><br />

    <label>Product Price:</label>
    <asp:TextBox ID="txtProdPrice" runat="server"></asp:TextBox><br />

    <label>Product Quantity:</label>
    <asp:TextBox ID="txtProdQty" runat="server"></asp:TextBox><br />

    <label>Product Description:</label>
    <asp:TextBox ID="txtProdDesc" runat="server" TextMode="MultiLine"></asp:TextBox><br />

    <label>Category:</label>
    <asp:DropDownList ID="dlCategory" runat="server"></asp:DropDownList><br />

    <asp:Button ID="addBtn" runat="server" Text="Add Product" OnClick="addBtn_Click" /><br />
    <asp:Label ID="lblText" runat="server" ForeColor="Red"></asp:Label>
</div>
        
     </section>
 </div>
        
    </form>
</body>
</html>
