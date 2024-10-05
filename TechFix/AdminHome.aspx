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
                            <li>
                                <asp:Button ID="btnaddCategories" runat="server" class="nav__link" Text="Add Categories" OnClick="btnaddCategories_Click" />
                            </li>
                            <li><a href="welcome.php" class="nav__link">Menu</a></li>
                            <li><a href="welcome.php" class="nav__link">Live</a></li>
                            <li><a href="welcome.php" class="nav__link">Orders</a></li>
                            <li><a href="welcome.php" class="nav__link">Reservation</a></li>
                            <li><a href="about.php" class="nav__link">About Us</a></li>
                            <li><a href="welcome.php" class="nav__link">Profile</a></li>
                            <li>
                                <a href="welcome.php" class="login" id="loginbutton">Log In</a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </header>
        </div>
    </form>
</body>
</html>
