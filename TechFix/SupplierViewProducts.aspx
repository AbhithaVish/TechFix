<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierViewProducts.aspx.cs" Inherits="TechFix.SupplierViewProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Products - Supplier</title>
    <link href="adminStyles.css" rel="stylesheet" />
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
                            <li><asp:Button ID="btnAddProducts" runat="server" class="nav__link" Text="Add Products" /> </li>
                            <li> <asp:Button ID="btnviewProducts" runat="server" class="nav__link" Text="View Products"  /></li>
                            <li> <asp:Button ID="btnquotation" runat="server" class="nav__link" Text="Quotations" /> </li>
                            <li><asp:Button ID="Button1" runat="server" class="nav__link" Text="Orders"/>  </li>
                            <li> <asp:Button ID="btnStock" runat="server" class="nav__link" Text="Stock Orders"  /></li>
                            <li><asp:Button ID="btnCus" runat="server" class="nav__link" Text="Customers" /> </li>

                            <li> <a href="welcome.php" class="login" id="loginbutton">Log Out</a> </li>
                        </ul>
                    </div>
                </nav>
            </header>
            <div class="content">
                <asp:Label ID="lblText" runat="server" Text="Label"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
                 </div>

            <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>

            
        </div>
    </form>
</body>
</html>
