using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is logged in by verifying the session variable
                if (Session["username"] == null)
                {
                    Response.Redirect("LoginForm.aspx"); // Redirect to login if not logged in
                }
                else
                {
                    string username = Session["username"].ToString();
                    // You can now use 'username' for display or logic
                    lblWelcome.Text = $"Welcome, {username}!"; // Assuming you have a label to display the username
                }
            }
        }

        protected void btncate_Click(object sender, EventArgs e)
        {
            Response.Redirect("addCategories.aspx");
        }

        protected void btnsup_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminViewProducts.aspx");
        }
    }
}