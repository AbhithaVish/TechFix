using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // Use appropriate namespace for your data access
using System.Web.UI.WebControls;

namespace TechFix.Customer
{
    public partial class Quotation : System.Web.UI.Page
    {
        CusOrderServiceReference.CusOrderWebServiceSoapClient obj = new CusOrderServiceReference.CusOrderWebServiceSoapClient();
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("../CusLogin.aspx");
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
                    "FROM Quotation ct", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable cart = new DataTable();
                da.Fill(cart);

                if (cart.Rows.Count == 0)
                {
                    cartMessage.Text = "Your Quotation is empty.";
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
                lblText.Text = "Error loading Quotations: " + ex.Message;
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
                RemoveItem(e);  // Calls the updated RemoveItem method
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
                    "UPDATE Quotation SET productQty = @newQuantity WHERE productName = @productName", con);
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

                // Step 1: Get the quantity of the item being removed
                SqlCommand getQtyCmd = new SqlCommand(
                    "SELECT productQty FROM Quotation WHERE productName = @productName", con);
                getQtyCmd.Parameters.AddWithValue("@productName", productName);

                int removedQuantity = Convert.ToInt32(getQtyCmd.ExecuteScalar());

                // Step 2: Update the quantity of the product in ProductsTable
                SqlCommand updateProductCmd = new SqlCommand(
                    "UPDATE CusProductsTable SET productQty = productQty + @removedQuantity WHERE productName = @productName", con);
                updateProductCmd.Parameters.AddWithValue("@removedQuantity", removedQuantity);
                updateProductCmd.Parameters.AddWithValue("@productName", productName);

                updateProductCmd.ExecuteNonQuery();

                // Step 3: Remove the item from the CartTable
                SqlCommand deleteCmd = new SqlCommand(
                    "DELETE FROM Quotation WHERE productName = @productName", con);
                deleteCmd.Parameters.AddWithValue("@productName", productName);

                deleteCmd.ExecuteNonQuery();

                LoadCart();  // Reload the cart after removal
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
                    Response.Redirect("Cusorders.aspx"); // Redirect to orders page
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
                    "DELETE FROM Quotation", con); // Clear all items in the CartTable
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


        protected void btndash_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CusHome.aspx");
        }

        protected void btnProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("CusProducts.aspx");
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("CusOrders.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Quotation.aspx");
        }

    }
}
