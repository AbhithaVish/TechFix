using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class SupplerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    lblWelcome.Text = "Welcome, " + Session["username"].ToString(); // Optional: display welcome message
                }
                else
                {
                    Response.Redirect("../SupplierLogin.aspx"); // Redirect to login if not logged in
                }
            }
        }

        protected void btnAddProducts_Click1(object sender, EventArgs e)
        {
            Response.Redirect("supplierAddProducts.aspx");
        }

        protected void btnviewProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierViewProducts.aspx");
        }

        protected void btnOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupOrders.aspx");
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplerHome.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SupplierLogin.aspx");
        }
    }
}