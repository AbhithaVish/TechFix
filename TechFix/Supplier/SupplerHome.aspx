    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplerHome.aspx.cs" Inherits="TechFix.SupplerHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supplier Home Page</title>
    <link href="../CSS/SupplierStyle.css" rel="stylesheet" />
    <style>
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
                      <asp:Label ID="lblWelcome" runat="server" Text="Label"></asp:Label>
                  </div>
         </div>
    </form>
</body>
</html>
