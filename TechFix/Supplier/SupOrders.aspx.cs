using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class SupOrders : System.Web.UI.Page
    {
        private string connectionString = "data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("../SupplierLogin.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            string username = Session["username"].ToString();  // Get the logged-in supplier's username

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT OrderId, productName, productQty, username, price, status " +
                               "FROM OrderTable WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable orders = new DataTable();
                da.Fill(orders);

                if (orders.Rows.Count == 0)
                {
                    ordersMessage.Text = "No orders available.";
                }
                else
                {
                    orderList.DataSource = orders;
                    orderList.DataBind();
                }
            }
        }

        protected void orderList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "UpdateStatus")
            {
                string argument = e.CommandArgument.ToString();

                if (int.TryParse(argument, out int orderId))
                {
                    DropDownList ddlStatus = (DropDownList)e.Item.FindControl("ddlStatus");
                    string newStatus = ddlStatus.SelectedValue.Trim();  // Ensure nchar compatibility

                    UpdateOrderStatus(orderId, newStatus);
                    LoadOrders();  // Reload orders to reflect status updates
                }
                else
                {
                    lblText.Text = "Invalid order ID.";
                }
            }
        }

        private void UpdateOrderStatus(int orderId, string newStatus)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Update the order status
                        string query = "UPDATE OrderTable SET status = @status WHERE OrderId = @orderId";
                        SqlCommand cmd = new SqlCommand(query, con, transaction);
                        cmd.Parameters.AddWithValue("@status", newStatus.PadRight(50));  // Handle nchar(50)
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.ExecuteNonQuery();

                        // If the status is "Approved", reduce the product quantity
                        if (newStatus == "Approved")
                        {
                            ReduceProductQuantity(orderId, con, transaction);
                        }

                        transaction.Commit();
                        lblText.Text = "Status updated successfully.";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        lblText.Text = "Error updating status: " + ex.Message;
                    }
                }
            }
        }

        private void ReduceProductQuantity(int orderId, SqlConnection con, SqlTransaction transaction)
        {
            // Retrieve the product name, quantity, and username from OrderTable
            string query = "SELECT productName, productQty, username FROM OrderTable WHERE OrderId = @orderId";
            SqlCommand cmd = new SqlCommand(query, con, transaction);
            cmd.Parameters.AddWithValue("@orderId", orderId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string productName = reader["productName"].ToString();
                    int orderQty = Convert.ToInt32(reader["productQty"]);
                    string username = reader["username"].ToString();
                    reader.Close();  // Close reader before updating

                    // Update the quantity in ProductsTable for the specific supplier (username)
                    string updateProductQuery = @"
                        UPDATE ProductsTable 
                        SET Qauntity = Qauntity - @orderQty 
                        WHERE ItemName = @productName AND username = @username";
                    SqlCommand updateCmd = new SqlCommand(updateProductQuery, con, transaction);
                    updateCmd.Parameters.AddWithValue("@orderQty", orderQty);
                    updateCmd.Parameters.AddWithValue("@productName", productName);
                    updateCmd.Parameters.AddWithValue("@username", username);

                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Order not found.");
                }
            }
        }
        protected void btnAddProducts_Click1(object sender, EventArgs e)
        {
            Response.Redirect("supplierAddProducts.aspx");
        }

        protected void btnviewProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierViewProducts.aspx");
        }

        protected void btnOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupOrders.aspx");
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplerHome.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SupplierLogin.aspx");
        }
    }
}
