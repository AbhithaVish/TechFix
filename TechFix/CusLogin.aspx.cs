using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class CusLogin : System.Web.UI.Page
    {
        CusloginServiceReference.CusLoginWebServiceSoapClient obj = new CusloginServiceReference.CusLoginWebServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            
                // Call the web service's ValidateUser method
                bool isValidUser = obj.ValidateUser(txtusername.Text, txtpassword.Text);

                if (isValidUser)
                {
                    // Set the session and redirect to AdminHome if valid
                    Session["username"] = txtusername.Text;
                    lbltext.Text = "User Login Success";
                    Response.Redirect("Customer/CusHome.aspx");
                }
                else
                {
                    // Display error message for invalid login
                    lbltext.Text = "User Authentication Failed.";
                    lbltext.ForeColor = System.Drawing.Color.Red; // Optionally set color for visibility
                }
            
        }
    }
}