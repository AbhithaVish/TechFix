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
    public partial class SupplierLogin : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
                con.Open();//connecting to the database
            }
            catch (Exception ex)
            {
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
                // Use parameterized queries to prevent SQL injection
                string query = "SELECT COUNT(*) FROM SuppliersTable WHERE username = @username AND password = @password";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);

                int userCount = (int)cmd.ExecuteScalar();

                if (userCount > 0)
                {
                    Session["username"] = txtusername.Text; // Store the username in the session
                    Response.Redirect("SupplerHome.aspx");
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