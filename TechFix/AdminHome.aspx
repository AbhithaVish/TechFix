<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="TechFix.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Home Page</title>
    <link href="adminStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header class="header">
                <nav class="nav container">
                    <div class="nav__menu">
                        <ul class="nav__list">
                            <li><asp:Button ID="btnaddCategories" runat="server" class="nav__link" Text="Add Categories" OnClick="btnaddCategories_Click" /></li>
                            <li><asp:Button ID="btnAddProducts" runat="server" class="nav__link" Text="Add Products" OnClick="btnaddCategories_Click" /> </li>
                            <li> <asp:Button ID="btnquotation" runat="server" class="nav__link" Text="Quotations" OnClick="btnaddCategories_Click" /> </li>
                            <li><asp:Button ID="btnOrders" runat="server" class="nav__link" Text="Orders" OnClick="btnaddCategories_Click" />  </li>
                            <li> <asp:Button ID="btnStock" runat="server" class="nav__link" Text="Stock Orders" OnClick="btnaddCategories_Click" /></li>
                            <li><asp:Button ID="btnCus" runat="server" class="nav__link" Text="Customers" OnClick="btnaddCategories_Click" /> </li>

                            <li> <a href="welcome.php" class="login" id="loginbutton">Log Out</a> </li>
                        </ul>
                    </div>
                </nav>
            </header>
        </div>
    </form>
</body>
</html>
