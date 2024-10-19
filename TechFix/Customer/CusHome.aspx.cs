using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class CusHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in by verifying the session variable
            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();  // Retrieve the username
                lblWelcome.Text = $"Welcome, {username}!";  // Display it on the page
            }
            else
            {
                // Redirect to login if the session is not set
                Response.Redirect("../CusLogin.aspx");
            }
        }

        protected void btndash_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CusHome.aspx");
        }

        protected void btnProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("CusProducts.aspx");
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("CusOrders.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Quotation.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CusLogin.aspx");
        }
    }
}
