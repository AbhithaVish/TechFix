<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="TechFix.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Home Page</title>
    <link href="adminStyles.css" rel="stylesheet" />
    <style>
        body{
/*            background-image: url('../Images/admin background.png');*/
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
                            <li><asp:Button ID="btndash" runat="server" class="nav__link" Text="Dashboard" /></li>
                            <li><asp:Button ID="btnOrder" runat="server" class="nav__link" Text="Order Management" /></li>
                            <li><asp:Button ID="btnStock" runat="server" class="nav__link" Text="Stock Management" /> </li>
                            <li> <asp:Button ID="btnCus" runat="server" class="nav__link" Text="Customer Management"  /> </li>
                            <li><asp:Button ID="btnsup" runat="server" class="nav__link" Text="Suppliers" OnClick="btnsup_Click" style="height: 22px" />  </li>
                            <li> <asp:Button ID="btncate" runat="server" class="nav__link" Text="Categories" OnClick="btncate_Click"  /></li>

                            <li> <a href="welcome.php" class="login" id="loginbutton">Log Out</a> </li>
                        </ul>
                    </div>
                </nav>
            </header>
        </div>
    </form>
</body>
</html>
