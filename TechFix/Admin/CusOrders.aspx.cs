using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix.Admin
{
    public partial class CusOrders : System.Web.UI.Page
    {
        private string connectionString = "data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("../LoginForm.aspx");
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
                string query = "SELECT OrderId, productName, productQty, username, price, status, OrderLine_Id " +
                               "FROM CusOrderTable WHERE username = @username";
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

                if (int.TryParse(argument, out int orderLineId))
                {
                    DropDownList ddlStatus = (DropDownList)e.Item.FindControl("ddlStatus");
                    string newStatus = ddlStatus.SelectedValue.Trim();

                    // Attempt to update the order status based on OrderLine_Id
                    if (UpdateOrderStatus(orderLineId, newStatus))
                    {
                        lblText.Text = "Order status updated successfully.";
                    }
                    else
                    {
                        lblText.Text = "Failed to update order status.";
                    }
                    LoadOrders();  // Reload orders to reflect status updates
                }
                else
                {
                    lblText.Text = "Invalid order line ID.";
                }
            }
            else if (e.CommandName == "Edit")
            {
                // Redirect to edit order page, pass OrderLine_Id as a parameter
                string orderLineId = e.CommandArgument.ToString();
                Response.Redirect($"EditOrder.aspx?OrderLineId={orderLineId}");
            }
            else if (e.CommandName == "Delete")
            {
                string orderLineId = e.CommandArgument.ToString();

                // Output the raw value for debugging
                lblText.Text = "OrderLine_Id (raw value): " + orderLineId;

                if (int.TryParse(orderLineId, out int orderLineIdParsed))
                {
                    if (DeleteOrder(orderLineIdParsed))
                    {
                        lblText.Text = "Order deleted successfully.";
                    }
                    else
                    {
                        lblText.Text = "Error deleting order. Please try again.";
                    }
                }
                else
                {
                    lblText.Text = "Invalid order line ID: " + orderLineId;
                }

                LoadOrders(); // Reload orders after deletion
            }

        }

        private bool UpdateOrderStatus(int orderLineId, string newStatus)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE CusOrderTable SET status = @status WHERE OrderLine_Id = @orderLineId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@orderLineId", orderLineId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if the update was successful
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error updating order status: " + ex.Message;
                return false; // Return false on failure
            }
        }

        private bool DeleteOrder(int orderLineId)
        {
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM CusOrderTable WHERE OrderLine_Id = @orderLineId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderLineId", orderLineId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if the deletion was successful
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error deleting order: " + ex.Message;
                return false; // Return false on failure
            }
        }



        protected void btndash_Click(object sender, EventArgs e) => Response.Redirect("AdminHome.aspx");

        protected void btnSup_Click(object sender, EventArgs e) => Response.Redirect("Suppliers.aspx");

        protected void btnStocks_Click(object sender, EventArgs e) => Response.Redirect("adminManageProducts.aspx");

        protected void Button2_Click(object sender, EventArgs e) => Response.Redirect("cart.aspx");

        protected void btnOrders_Click(object sender, EventArgs e) => Response.Redirect("orders.aspx");

        protected void btnCUs_Click(object sender, EventArgs e) => Response.Redirect("customers.aspx");

        protected void Button1_Click(object sender, EventArgs e) => Response.Redirect("addcategories.aspx");

        protected void Button3_Click(object sender, EventArgs e) => Response.Redirect("adminViewProducts.aspx");

        protected void Button4_Click(object sender, EventArgs e) => Response.Redirect("CusOrders.aspx");

        protected void Button5_Click(object sender, EventArgs e) => Response.Redirect("adminAddProducts.aspx");
    }
}
