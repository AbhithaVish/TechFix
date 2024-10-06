using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.SqlClient;
using System.Data;

namespace TechFix
{
    public partial class SupplierViewProducts : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix;Integrated Security=True");
                con.Open();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error connecting to the database: " + ex.Message;
            }

            if (!IsPostBack)
            {
                LoadCustomerData();
            }
        }
        private void LoadCustomerData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT ItemId, ItemName, Description, Price, Stock,Category,Warranty  FROM Product_Supplier", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind data to GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error loading data: " + ex.Message;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}