using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TechFix
{
    public partial class addcategories : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix;Integrated Security=True");
                con.Open();//connecting to the databas
            }
            catch (Exception ex)
            {
                lbltext.Text = "Error Connecting to the database" + ex;

            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Categories values('" + txtid.Text + "','" + txtcategory.Text + "')", con);
                int NoRows = cmd.ExecuteNonQuery();

                if (NoRows > 0)
                {
                    lbltext.Text = "Record added successfully!";
                }
                else
                {
                    lbltext.Text = "Failed to add customer.";
                }
            }
            catch (Exception ex)
            {
                lbltext.Text = "Error inserting data " + ex;
            }
        }
    }
}