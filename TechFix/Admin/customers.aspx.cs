using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix.Admin
{
    public partial class cusomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSuppliersData(); // Call the method to bind data on initial load
            }
        }


        private void BindSuppliersData()
        {
            // Define connection string and query to get suppliers
            SqlConnection con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            string query = "SELECT TOP (1000) username, name FROM SuppliersTable"; // Removed password
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind the supplier data to GridView
                SuppliersGridView.DataSource = dt;
                SuppliersGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void SuppliersGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row in edit mode
            SuppliersGridView.EditIndex = e.NewEditIndex;
            BindSuppliersData(); // Rebind data to show edit mode
        }

        protected void SuppliersGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Retrieve values from the GridView
            GridViewRow row = SuppliersGridView.Rows[e.RowIndex];
            string username = (string)SuppliersGridView.DataKeys[e.RowIndex].Values[0];
            string name = (row.FindControl("txtName") as TextBox).Text;

            // Update supplier data in database
            SqlConnection con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            string updateQuery = "UPDATE SuppliersTable SET name=@name WHERE username=@username"; // Removed password
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@username", username);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                SuppliersGridView.EditIndex = -1; // Exit edit mode
                BindSuppliersData(); // Refresh data
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void SuppliersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string username = (string)SuppliersGridView.DataKeys[e.RowIndex].Values[0];

            SqlConnection con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            string deleteQuery = "DELETE FROM SuppliersTable WHERE username=@username";
            SqlCommand cmd = new SqlCommand(deleteQuery, con);
            cmd.Parameters.AddWithValue("@username", username);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                BindSuppliersData(); // Refresh the GridView after deletion
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void SuppliersGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel the editing mode
            SuppliersGridView.EditIndex = -1;
            BindSuppliersData(); // Refresh data
        }

        protected void btndash_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }

        protected void btnSup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Suppliers.aspx");
        }

        protected void btnStocks_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminManageProducts.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("cart.aspx");
        }

        protected void btnOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("orders.aspx");
        }

        protected void btnCUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("customers.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("addcategories.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminViewProducts.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("CusOrders.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminAddProducts.aspx");
        }
    }
}