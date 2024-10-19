<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CusHome.aspx.cs" Inherits="TechFix.CusHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Profile - Home Page</title>
    <link href="../CSS/CustomerNav.css" rel="stylesheet" />
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
            <asp:Label ID="lblWelcome" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
