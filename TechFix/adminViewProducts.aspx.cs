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
            con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            con.Open();

            // Load products only on first page load (not on postback)
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
                // Select the required columns
                SqlCommand cmd = new SqlCommand("SELECT productID, productName, productDesc, productPrice, productQty, username, categoryId FROM ProductsTable", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind the data to the Repeater control
                productRepeater.DataSource = dt;
                productRepeater.DataBind();
            }
            catch (Exception ex)
            {
                // Display error message in case of failure
                lblText.Text = "Error loading products: " + ex.Message;
            }
        }

        // Method to handle Add to Cart button click events
        protected void productRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productID = Convert.ToInt32(e.CommandArgument); // Get productID from command argument

                // Create or retrieve the cart from the session
                DataTable cart;
                if (Session["Cart"] == null)
                {
                    cart = new DataTable();
                    cart.Columns.Add("productID", typeof(int));
                    cart.Columns.Add("productName", typeof(string));
                    cart.Columns.Add("productPrice", typeof(decimal));
                }
                else
                {
                    cart = (DataTable)Session["Cart"];
                }

                // Fetch the product details for the selected product
                SqlCommand cmd = new SqlCommand("SELECT productID, productName, productPrice FROM ProductsTable WHERE productID = @productID", con);
                cmd.Parameters.AddWithValue("@productID", productID);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // Add the product details to the cart
                    DataRow row = cart.NewRow();
                    row["productID"] = dr["productID"];
                    row["productName"] = dr["productName"];
                    row["productPrice"] = dr["productPrice"];
                    cart.Rows.Add(row);
                }
                dr.Close();

                // Save the cart back into the session
                Session["Cart"] = cart;
            }
        }

        // Method to redirect to the cart page when 'View Cart' is clicked
        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("cart.aspx");
        }
    }
}
