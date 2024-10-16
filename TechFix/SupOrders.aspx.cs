using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ClientWebApplication;  

namespace TechFix
{
    public partial class SupOrders : System.Web.UI.Page
    {
        private string connectionString = "data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True";
       // SupOrdersWebService orderService = new SupOrdersWebService();  // Initialize the correct web service

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("LoginForm.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            string username = Session["username"].ToString();  // Get the logged-in username

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT OrderId, productName, productQty, username, price, status FROM OrderTable WHERE username = @username";
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
                int orderId = Convert.ToInt32(e.CommandArgument);
                DropDownList ddlStatus = (DropDownList)e.Item.FindControl("ddlStatus");
                string newStatus = ddlStatus.SelectedValue;

                // Call the web service to update the order status
               // string result = orderService.UpdateOrderStatus(orderId, newStatus);
               // lblText.Text = result;

                LoadOrders();  // Reload orders to reflect status updates
            }
        }
    }
}
