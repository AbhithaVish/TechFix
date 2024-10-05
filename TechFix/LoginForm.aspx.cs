using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

namespace TechFix
{
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix;Integrated Security=True");
                con.Open();//connecting to the database
            }
            catch (Exception ex){
                lbltext.Text = "Error Connecting to the database" + ex;

            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                // Directly using txtusername.Text and txtpassword.Text in the query
                string query = "SELECT COUNT(*) FROM Admin_login WHERE username = '" + txtusername.Text + "' AND password = '" + txtpassword.Text + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                int userCount = (int)cmd.ExecuteScalar();

                if (userCount > 0)
                {
                    Response.Redirect("AdminHome.aspx");
                }
                else
                {
                    lbltext.Text = "Invalid Username or Password.";
                }
            }
            catch (Exception ex)
            {
                lbltext.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

    }
}