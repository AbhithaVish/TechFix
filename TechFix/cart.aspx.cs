using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class cart : System.Web.UI.Page
    {
        // Web service client to access OrderWebService
        OrderServiceReference.OrderWebServiceSoapClient obj = new OrderServiceReference.OrderWebServiceSoapClient();
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

        private void LoadCart()
        {
            try
            {
                // Query to select data from CartTable without username filtering
                SqlCommand cmd = new SqlCommand(
                    "SELECT ct.productName, ct.productQty AS Quantity, ct.price AS productPrice, " +
                    "(ct.productQty * ct.price) AS TotalPrice, ct.username " +
                    "FROM CartTable ct", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable cart = new DataTable();
                da.Fill(cart);

                if (cart.Rows.Count == 0)
                {
                    cartMessage.Text = "Your cart is empty.";
                }
                else
                {
                    cartRepeater.DataSource = cart;
                    cartRepeater.DataBind();

                    decimal totalPrice = 0;
                    foreach (DataRow row in cart.Rows)
                    {
                        totalPrice += Convert.ToDecimal(row["TotalPrice"]);
                    }
                    totalPriceLiteral.Text = "Total Price: Rs." + totalPrice.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error loading cart: " + ex.Message;
            }
        }

        protected void cartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                UpdateQuantity(e);
            }
            else if (e.CommandName == "Remove")
            {
                RemoveItem(e);
            }
        }

        private void UpdateQuantity(RepeaterCommandEventArgs e)
        {
            try
            {
                string productName = e.CommandArgument.ToString();
                TextBox txtQuantity = (TextBox)e.Item.FindControl("quantityTextBox");
                int newQuantity = Convert.ToInt32(txtQuantity.Text);

                // Ensure that the new quantity is not less than 1
                if (newQuantity < 1)
                {
                    lblText.Text = "Quantity must be at least 1.";
                    return;
                }

                SqlCommand cmd = new SqlCommand(
                    "UPDATE CartTable SET productQty = @newQuantity WHERE productName = @productName", con);
                cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                cmd.Parameters.AddWithValue("@productName", productName);

                cmd.ExecuteNonQuery();
                LoadCart();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error updating quantity: " + ex.Message;
            }
        }

        private void RemoveItem(RepeaterCommandEventArgs e)
        {
            try
            {
                string productName = e.CommandArgument.ToString();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM CartTable WHERE productName = @productName", con);
                cmd.Parameters.AddWithValue("@productName", productName);

                cmd.ExecuteNonQuery();
                LoadCart();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error removing item: " + ex.Message;
            }
        }

        // Use web service to save order on checkout
        protected void Checkout_Click(object sender, EventArgs e)
        {
            try
            {
                // Call the SaveOrder method without passing the session username.
                string result = obj.SaveOrder();

                if (result.StartsWith("Order placed successfully"))
                {
                    ClearCartAfterCheckout(); // Clear all items in the cart
                    Response.Redirect("orders.aspx"); // Redirect to orders page
                }
                else
                {
                    lblText.Text = result; // Display any error messages
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error during checkout: " + ex.Message;
            }
        }

        private void ClearCartAfterCheckout()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM CartTable", con); // Clear all items in the CartTable
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error clearing cart: " + ex.Message;
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
