using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ClientWebApplication
{
    /// <summary>
    /// Summary description for AdminOrdersWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdminOrdersWebService : System.Web.Services.WebService
    {
        private string connectionString = "data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True";

        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        [WebMethod]
        public string UpdateOrderStatus(int orderId, string newStatus)
        {
            try
            {
                using (var con = GetConnection())
                {
                    con.Open();
                    // Start a transaction to ensure atomicity
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // Update the order status
                            SqlCommand updateCmd = new SqlCommand(
                                "UPDATE CusOrderTable SET status = @status WHERE OrderId = @orderId", con, transaction);
                            updateCmd.Parameters.AddWithValue("@status", newStatus);
                            updateCmd.Parameters.AddWithValue("@orderId", orderId);
                            updateCmd.ExecuteNonQuery();

                            // If status is approved, reduce product quantity
                            if (newStatus == "Approved")
                            {
                                ReduceProductQuantity(orderId, con, transaction);
                            }

                            transaction.Commit();  // Commit the transaction
                            return "Order status updated successfully.";
                        }
                        catch
                        {
                            transaction.Rollback();  // Rollback on failure
                            throw;  // Rethrow exception to be caught by outer try-catch
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error updating status: " + ex.Message;
            }
        }

        private void ReduceProductQuantity(int orderId, SqlConnection con, SqlTransaction transaction)
        {
            // Retrieve product name and quantity from OrderTable
            SqlCommand getOrderCmd = new SqlCommand(
                "SELECT productName, productQty FROM CusOrderTable WHERE OrderId = @orderId", con, transaction);
            getOrderCmd.Parameters.AddWithValue("@orderId", orderId);

            using (SqlDataReader reader = getOrderCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string productName = reader["productName"].ToString();
                    int orderQty = Convert.ToInt32(reader["productQty"]);
                    reader.Close();  // Close the reader before updating

                    // Update ProductsTable to reduce quantity
                    SqlCommand updateProductCmd = new SqlCommand(
                        "UPDATE CusProductsTable SET Qauntity = Qauntity - @orderQty WHERE ItemName = @productName", con, transaction);
                    updateProductCmd.Parameters.AddWithValue("@orderQty", orderQty);
                    updateProductCmd.Parameters.AddWithValue("@productName", productName);

                    updateProductCmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Order not found.");
                }
            }
        }
    }
}
