using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix.Customer
{
    public partial class CusOrders : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirect if no user is logged in
            if (Session["username"] == null)
            {
                Response.Redirect("../CusLoginForm.aspx");
                return;
            }

            con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            con.Open();

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            try
            {
                // Fetch all orders from the OrderTable
                SqlCommand cmd = new SqlCommand(
                    "SELECT OrderId, productName, productQty, price, status FROM OrderTable", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable orders = new DataTable();
                da.Fill(orders);

                if (orders.Rows.Count == 0)
                {
                    ordersMessage.Text = "No orders available.";
                }
                else
                {
                    ordersRepeater.DataSource = orders;
                    ordersRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                ordersMessage.Text = "Error loading orders: " + ex.Message;
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (con?.State == ConnectionState.Open)
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CusLogin.aspx");
        }
    }
}