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
    public partial class adminAddProducts : System.Web.UI.Page
    {
        AdminAddProductsServiceReference.AdminAddProductsWebServiceSoapClient obj = new AdminAddProductsServiceReference.AdminAddProductsWebServiceSoapClient();
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            con.Open();

            if (!IsPostBack)
            {
                getCategoryName(); // Only fetch categories as the supplier dropdown is no longer needed
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                decimal productPrice;
                int productQty;

                if (!decimal.TryParse(txtProdPrice.Text, out productPrice))
                {
                    lblText.Text = "Invalid product price.";
                    return;
                }

                if (!int.TryParse(txtProdQty.Text, out productQty))
                {
                    lblText.Text = "Invalid product quantity.";
                    return;
                }

                // Get the logged-in username from the session
                string username = Session["username"] != null ? Session["username"].ToString() : string.Empty;

                if (string.IsNullOrEmpty(username))
                {
                    lblText.Text = "You must be logged in to add products.";
                    return;
                }

                // Generate a new product ID
                string productId = AutoProductId();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO CusProductsTable (productID, productName, productPrice, productQty, productDesc, username, categoryId) " +
                    "VALUES (@productID, @productName, @productPrice, @productQty, @productDesc, @username, @categoryId)", con);

                cmd.Parameters.AddWithValue("@productID", productId);
                cmd.Parameters.AddWithValue("@productName", txtProdName.Text);
                cmd.Parameters.AddWithValue("@productPrice", productPrice);
                cmd.Parameters.AddWithValue("@productQty", productQty);
                cmd.Parameters.AddWithValue("@productDesc", txtProdDesc.Text);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@categoryId", dlCategory.SelectedValue);

                int NoRows = cmd.ExecuteNonQuery();

                if (NoRows > 0)
                {
                    lblText.Text = "Record added successfully!";
                    txtProdName.Text = "";
                    txtProdPrice.Text = "";
                    txtProdQty.Text = "";
                    txtProdDesc.Text = "";
                }
                else
                {
                    lblText.Text = "Record was not added.";
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error inserting data: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        private void getCategoryName()
        {
            SqlCommand cmd = new SqlCommand("SELECT categoryName, categoryId FROM CategoryTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dlCategory.DataSource = dt;
            dlCategory.DataTextField = "categoryName";
            dlCategory.DataValueField = "categoryId";
            dlCategory.DataBind();
            dlCategory.Items.Insert(0, new ListItem("Select category", ""));
        }

        // AutoProductId method to generate unique product IDs
        public string AutoProductId()
        {
            string ProductId = null;

            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT TOP 1 productID FROM CusProductsTable ORDER BY productID DESC", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    string lastId = dr[0].ToString(); // Get the latest product ID (e.g., "P003")
                    dr.Close();

                    // Extract the numeric part from the ID (e.g., "003")
                    string numericPart = lastId.Substring(1);
                    int newIdNum = int.Parse(numericPart) + 1; // Increment the numeric part

                    // Format the new ID based on its value (P001, P010, etc.)
                    if (newIdNum < 10)
                        ProductId = "P00" + newIdNum;
                    else if (newIdNum < 100)
                        ProductId = "P0" + newIdNum;
                    else
                        ProductId = "P" + newIdNum;
                }
                else
                {
                    // If there are no existing records, start with "P001"
                    ProductId = "P001";
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                ProductId = "Error: " + ex.Message;
            }

            return ProductId;
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
