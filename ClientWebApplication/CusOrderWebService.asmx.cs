using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ClientWebApplication
{
    /// <summary>
    /// Summary description for CusOrderWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CusOrderWebService : System.Web.Services.WebService
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
                        "INSERT INTO CusOrderTable (OrderId, productName, productQty, price, username, status) " +
                        "SELECT @OrderId, productName, productQty, (productQty * price), username, 'Pending' " +
                        "FROM Quotation WHERE productQty > 0", con);

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


        [WebMethod]
        public string AutoOrderId()
        {
            string OrderId = null;
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();  // Open the connection

                    SqlCommand cmd = new SqlCommand("SELECT MAX(OrderId) FROM CusOrderTable", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    string id = "";

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            id = dr[0]?.ToString();
                        }

                        if (!string.IsNullOrEmpty(id))
                        {
                            string idString = id.Substring(2);  // Substring starts at index 2
                            int CTR = int.Parse(idString);

                            if (CTR < 9)
                                OrderId = "OI00" + (CTR + 1);
                            else if (CTR < 99)
                                OrderId = "OI0" + (CTR + 1);
                            else
                                OrderId = "OI" + (CTR + 1);
                        }
                        else
                        {
                            OrderId = "OI001";
                        }
                    }
                    else
                    {
                        OrderId = "OI001";
                    }

                    dr.Close();  // Close the reader properly
                }
            }
            catch (Exception ex)
            {
                OrderId = "Error generating OrderId: " + ex.Message;
            }
            return OrderId;
        }




        // Clears the user's cart after order placement
        private void ClearCart()
        {
            using (var con = GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Quotation WHERE productQty = 0", con); // Clear all items from the cart
                cmd.ExecuteNonQuery();
            }
        }
    }
}
