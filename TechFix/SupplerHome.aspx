    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplerHome.aspx.cs" Inherits="TechFix.SupplerHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supplier Home Page</title>
    <link href="adminStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

      <div>
             <header class="header">
                 <nav class="nav container">
                     <div class="nav__menu">
                         <ul class="nav__list">
                             <li><asp:Button ID="btnAddProducts" runat="server" class="nav__link" Text="Add Products" OnClick="btnAddProducts_Click"  /> </li>
                             <li> <asp:Button ID="btnviewProducts" runat="server" class="nav__link" Text="View Products" OnClick="btnviewProducts_Click"   /></li>
                             <li> <asp:Button ID="btnquotation" runat="server" class="nav__link" Text="Quotations" /> </li>
                             <li><asp:Button ID="Button1" runat="server" class="nav__link" Text="Orders"/>  </li>
                             <li> <asp:Button ID="btnStock" runat="server" class="nav__link" Text="Stock Orders"  /></li>
                             <li><asp:Button ID="btnCus" runat="server" class="nav__link" Text="Customers" /> </li>

                             <li> <a href="welcome.php" class="login" id="loginbutton">Log Out</a> </li>
                         </ul>
                     </div>
                 </nav>
             </header>
         </div>
    </form>
</body>
</html>
