using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace TechFix
{
    public partial class supplierAddProducts : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection
                   ("data source=localhost\\SQLEXPRESS;initial catalog=TechFix;Integrated Security=True");
                con.Open();

                getCategoryName();
            }

            catch (Exception ex)
            {
                lblText.Text = "Error connecting db" + ex;
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Product_Supplier VALUES('" + txtitemId.Text + "', '" + txtProductName.Text + "', '"+txtDescription.Text+ "', '" + txtProductPrice.Text + "' , '" + txtQuantity.Text + "', '" + getCategoryId() + "', '" + txtwarranty.Text + "');", con);

                int NoRows = cmd.ExecuteNonQuery();

                if (NoRows > 0)
                {
                    lblText.Text = "Record added successfully!";
                }
                else
                {
                    lblText.Text = "Failed to add customer.";
                }
            }

            catch (Exception ex)
            {
                lblText.Text = "Error inserting data " + ex;
            }
        }

        public void getCategoryName()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT CategoryName FROM Categories", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "CategoryTable");

                dlcategory.DataSource = ds;
                dlcategory.DataBind();
                dlcategory.DataValueField = "CategoryName";
                dlcategory.DataBind();
            }

            catch (Exception ex)
            {
                lblText.Text = "error selecting Department Name" + ex;
            }
        }

        public string getCategoryId()
        {
            string DepartmentId = "";
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT CategoryId FROM Categories WHERE CategoryName = '" + dlcategory.Text + "'", con);
                SqlDataReader datareader = cmd.ExecuteReader();

                bool records = datareader.HasRows;
                if (records)
                {
                    while (datareader.Read())
                    {
                        DepartmentId = datareader[0].ToString();
                    }
                }
                datareader.Close();
            }

            catch (Exception ex)
            {
                lblText.Text = "Ërror selecting category Id " + ex;
            }

            return DepartmentId;
        }
    }
}