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

        }
        
        protected void btnAddProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("supplierAddProducts.aspx");
        }

        protected void btnviewProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierViewProducts.aspx");
        }
    }
}