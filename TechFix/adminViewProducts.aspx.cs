using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class adminViewProducts : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirect if not logged in
            if (Session["username"] == null)
            {
                Response.Redirect("LoginForm.aspx");
                return;
            }

            // Establish SQL connection
            con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            // Load products only on the first page load (not on postback)
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        // Method to load products from the database
        private void LoadProducts()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT productID, productName, productDesc, productPrice, productQty, username, categoryId FROM ProductsTable", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind the data to the DataList control
                productList.DataSource = dt;
                productList.DataBind();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error loading products: " + ex.Message;
            }
        }

        // Method to handle Add to Cart button click events
        protected void productList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productID = Convert.ToInt32(e.CommandArgument);
                string loggedInUsername = Session["username"].ToString(); // Logged-in user

                try
                {
                    // Fetch the product details along with the supplier's username
                    SqlCommand cmd = new SqlCommand(
                        "SELECT productID, productName, productPrice, productQty, username AS supplierUsername " +
                        "FROM ProductsTable WHERE productID = @productID", con);
                    cmd.Parameters.AddWithValue("@productID", productID);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string productName = dr["productName"].ToString();
                        decimal price = Convert.ToDecimal(dr["productPrice"]);
                        string supplierUsername = dr["supplierUsername"].ToString(); // Get supplier's username
                        int availableQty = Convert.ToInt32(dr["productQty"]); // Get the available quantity

                        // Find the TextBox for quantity selection in the current DataList item
                        TextBox txtqty = (TextBox)e.Item.FindControl("txtqty");
                        int quantity = string.IsNullOrEmpty(txtqty.Text) ? 1 : Convert.ToInt32(txtqty.Text); // Default to 1 if not specified
                        decimal totalPrice = price * quantity;

                        // Check if there is enough quantity available
                        if (availableQty >= quantity)
                        {
                            // Insert product into the cart with the supplier's username
                            InsertIntoCartTable(productID, productName, quantity, price, totalPrice, supplierUsername);

                            // Update the productQty in ProductsTable after adding to cart
                            UpdateProductQuantity(productID, availableQty - quantity);

                            lblText.Text = "Product added to cart successfully!";
                        }
                        else
                        {
                            lblText.Text = "Insufficient quantity available.";
                        }
                    }
                    else
                    {
                        lblText.Text = "Product not found.";
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    lblText.Text = "Error adding to cart: " + ex.Message;
                }
            }
        }



        // Method to update the product quantity in the ProductsTable
        private void UpdateProductQuantity(int productID, int newQty)
        {
            string updateQuery = "UPDATE ProductsTable SET productQty = @newQty WHERE productID = @productID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, con))
            {
                cmd.Parameters.AddWithValue("@newQty", newQty);
                cmd.Parameters.AddWithValue("@productID", productID);
                cmd.ExecuteNonQuery();
            }
        }


        // Generate the next cart ID
        private int GetNextCartId()
        {
            string query = "SELECT ISNULL(MAX(id), 0) + 1 FROM CartTable";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Insert product into the CartTable
        private void InsertIntoCartTable(int productID, string productName, int quantity, decimal price, decimal totalPrice, string supplierUsername)
        {
            int newId = GetNextCartId();

            string query = "INSERT INTO CartTable (id, productID, productName, productQty, price, totalPrice, username) " +
                           "VALUES (@id, @productID, @productName, @productQty, @price, @totalPrice, @supplierUsername)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", newId);
                cmd.Parameters.AddWithValue("@productID", productID);
                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@productQty", quantity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                cmd.Parameters.AddWithValue("@supplierUsername", supplierUsername); // Save supplier's username

                cmd.ExecuteNonQuery();
            }
        }

        // Button to view the cart
        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("cart.aspx");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // Close the connection when the page is unloaded
            if (con != null)
            {
                con.Close();
            }
        }
    }
}
