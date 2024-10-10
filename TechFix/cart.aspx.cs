using System;
using System.Data;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        // Load cart items from session
        private void LoadCart()
        {
            DataTable cart = Session["Cart"] as DataTable;

            if (cart == null || cart.Rows.Count == 0)
            {
                cartMessage.Text = "<h3>Your cart is empty!</h3>";
                totalPriceLiteral.Text = "";
                cartRepeater.Visible = false;
                return;
            }

            // Add the Quantity column if not present, without the expression
            if (!cart.Columns.Contains("Quantity"))
            {
                cart.Columns.Add("Quantity", typeof(int)); // Removed expression
            }

            // Set default quantity to 1 for any item that doesn't have it
            foreach (DataRow row in cart.Rows)
            {
                if (row["Quantity"] == DBNull.Value || Convert.ToInt32(row["Quantity"]) == 0)
                {
                    row["Quantity"] = 1;
                }
            }

            // Add a calculated column for TotalPrice
            if (!cart.Columns.Contains("TotalPrice"))
            {
                cart.Columns.Add("TotalPrice", typeof(decimal), "productPrice * Quantity");
            }

            cartRepeater.DataSource = cart;
            cartRepeater.DataBind();

            // Calculate total price
            decimal totalPrice = 0;
            foreach (DataRow row in cart.Rows)
            {
                totalPrice += Convert.ToDecimal(row["TotalPrice"]);
            }
            totalPriceLiteral.Text = $"<h3>Total Price: ${totalPrice}</h3>";
        }

        protected void cartRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable cart = Session["Cart"] as DataTable;

            if (cart == null)
                return;

            int productID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Update")
            {
                // Find the item row and update the quantity
                foreach (DataRow row in cart.Rows)
                {
                    if (Convert.ToInt32(row["productID"]) == productID)
                    {
                        TextBox quantityTextBox = (TextBox)e.Item.FindControl("quantityTextBox");
                        int newQuantity = int.Parse(quantityTextBox.Text);
                        row["Quantity"] = newQuantity;
                        break;
                    }
                }
            }
            else if (e.CommandName == "Remove")
            {
                // Remove the item from the cart
                for (int i = cart.Rows.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToInt32(cart.Rows[i]["productID"]) == productID)
                    {
                        cart.Rows.RemoveAt(i);
                        break;
                    }
                }
            }

            Session["Cart"] = cart;
            LoadCart();
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            // Redirect to checkout page (or payment page)
            Response.Redirect("checkout.aspx");
        }
    }
}
