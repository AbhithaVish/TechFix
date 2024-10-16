using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ClientWebApplication
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class OrderWebService : WebService
    {
        private SqlConnection GetConnection()
        {
            string connectionString = "data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
        [WebMethod]
        public string SaveOrder()
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    string orderId = AutoOrderId();
                    if (orderId.StartsWith("Error"))
                    {
                        return orderId; // If AutoOrderId failed, return the error message.
                    }

                    // Insert order using the username from CartTable
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO OrderTable (OrderId, productName, productQty, price, username, status) " +
                        "SELECT @OrderId, productName, productQty, (productQty * price), username, 'Pending' " +
                        "FROM CartTable WHERE productQty > 0", con);

                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return "Order placed successfully with Order ID: " + orderId;
                    }
                    else
                    {
                        return "Failed to place the order. Please try again.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error placing order: " + ex.Message;
            }
        }



        private string AutoOrderId()
        {
            // Logic to generate a new unique order ID
            return "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        // Clears the user's cart after order placement
        private void ClearCart()
        {
            using (var con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM CartTable WHERE productQty = 0", con); // Clear all items from the cart
                cmd.ExecuteNonQuery();
            }
        }
    }
}
