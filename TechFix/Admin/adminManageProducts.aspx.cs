﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class adminManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductData();
            }
        }

        private void BindProductData()
        {
            // Define connection string and query to get products
            SqlConnection con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            string query = "SELECT productID, productName, productPrice, productQty, productDesc FROM ProductsTable";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind the product data to GridView
                ProductsGridView.DataSource = dt;
                ProductsGridView.DataBind();
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

        protected void ProductsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row in edit mode
            ProductsGridView.EditIndex = e.NewEditIndex;
            BindProductData();
        }

        protected void ProductsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Retrieve values from the GridView
            GridViewRow row = ProductsGridView.Rows[e.RowIndex];
            int productID = Convert.ToInt32(ProductsGridView.DataKeys[e.RowIndex].Values[0]);
            string productName = (row.FindControl("txtProductName") as TextBox).Text;
            decimal productPrice = Convert.ToDecimal((row.FindControl("txtProductPrice") as TextBox).Text);
            int productQty = Convert.ToInt32((row.FindControl("txtProductQty") as TextBox).Text);
            string productDesc = (row.FindControl("txtProductDesc") as TextBox).Text;

            // Update product data in database
            SqlConnection con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            string updateQuery = "UPDATE ProductsTable SET productName=@productName, productPrice=@productPrice, productQty=@productQty, productDesc=@productDesc WHERE productID=@productID";
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@productPrice", productPrice);
            cmd.Parameters.AddWithValue("@productQty", productQty);
            cmd.Parameters.AddWithValue("@productDesc", productDesc);
            cmd.Parameters.AddWithValue("@productID", productID);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                ProductsGridView.EditIndex = -1; // Exit edit mode
                BindProductData();
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

        protected void ProductsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productID = Convert.ToInt32(ProductsGridView.DataKeys[e.RowIndex].Values[0]);

            SqlConnection con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            string deleteQuery = "DELETE FROM ProductsTable WHERE productID=@productID";
            SqlCommand cmd = new SqlCommand(deleteQuery, con);
            cmd.Parameters.AddWithValue("@productID", productID);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                BindProductData(); // Refresh the GridView after deletion
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

        protected void ProductsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel the editing mode
            ProductsGridView.EditIndex = -1;
            BindProductData();
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