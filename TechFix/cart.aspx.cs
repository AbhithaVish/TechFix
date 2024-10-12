using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class cart : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("LoginForm.aspx");
                return;
            }

            con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            con.Open();

            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        // Initialize cart DataTable if it doesn't exist
        private void InitializeCart()
        {
            DataTable cart = new DataTable();
            cart.Columns.Add("productID", typeof(int));
            cart.Columns.Add("productName", typeof(string));
            cart.Columns.Add("productPrice", typeof(decimal));
            cart.Columns.Add("Quantity", typeof(int)); // Ensure Quantity column is present
            cart.Columns.Add("categoryId", typeof(string));

            Session["Cart"] = cart;
        }

        // Load cart items from session
        private void LoadCart()
        {
            DataTable cart = (DataTable)Session["Cart"];
            if (cart == null || cart.Rows.Count == 0)
            {
                cartMessage.Text = "Your cart is empty.";
                return;
            }

            cartRepeater.DataSource = cart;
            cartRepeater.DataBind();

            // Calculate total price
            decimal totalPrice = 0;
            foreach (DataRow row in cart.Rows)
            {
                totalPrice += Convert.ToDecimal(row["productPrice"]) * Convert.ToInt32(row["Quantity"]);
            }
            totalPriceLiteral.Text = "Total Price: $" + totalPrice.ToString("F2");
        }

        // Handle the checkout process
        protected void Checkout_Click(object sender, EventArgs e)
        {
            DataTable cart = (DataTable)Session["Cart"];
            string username = Session["username"].ToString();

            if (cart != null && cart.Rows.Count > 0)
            {
                foreach (DataRow row in cart.Rows)
                {
                    SaveOrder(row, username);
                }

                // Clear the cart after checkout
                Session["Cart"] = null;
                Response.Redirect("OrderConfirmation.aspx"); // Redirect to order confirmation page
            }
            else
            {
                lblText.Text = "Your cart is empty.";
            }
        }

        // Save order details to the database
        private void SaveOrder(DataRow row, string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True"))
                {
                    con.Open();
                    Random random = new Random();
                    int orderId = random.Next(100000, 999999); // Generate a random 6-digit order ID

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO orderTable (OrderId, productName, productQty, username, categoryId, status) VALUES (@OrderId, @productName, @productQty, @username, @categoryId, @status)", con))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.Parameters.AddWithValue("@productName", row["productName"]);
                        cmd.Parameters.AddWithValue("@productQty", row["Quantity"]);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@categoryId", row["categoryId"]);
                        cmd.Parameters.AddWithValue("@status", "pending");

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error saving order: " + ex.Message;
            }
        }

        // Event handler for item commands in the cart repeater
        protected void cartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable cart = (DataTable)Session["Cart"];
            if (cart != null)
            {
                if (e.CommandName == "Update")
                {
                    // Update quantity
                    int productID = Convert.ToInt32(e.CommandArgument);
                    TextBox txtQuantity = (TextBox)e.Item.FindControl("quantityTextBox");
                    int newQuantity = Convert.ToInt32(txtQuantity.Text);

                    // Find the row in the cart and update quantity
                    foreach (DataRow row in cart.Rows)
                    {
                        if (Convert.ToInt32(row["productID"]) == productID)
                        {
                            row["Quantity"] = newQuantity;
                            break;
                        }
                    }

                    // Reload the cart to reflect changes
                    LoadCart();
                }
                else if (e.CommandName == "Remove")
                {
                    // Remove item from cart
                    int productID = Convert.ToInt32(e.CommandArgument);

                    // Find the row in the cart and remove it
                    for (int i = cart.Rows.Count - 1; i >= 0; i--)
                    {
                        if (Convert.ToInt32(cart.Rows[i]["productID"]) == productID)
                        {
                            cart.Rows.RemoveAt(i);
                            break;
                        }
                    }

                    // Reload the cart to reflect changes
                    LoadCart();
                }
            }
        }
    }
}
