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

        }

        protected void btnaddCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("addcategories.aspx");
        }

        protected void btncate_Click(object sender, EventArgs e)
        {
            Response.Redirect("addcategories.aspx");
        }
    }
}