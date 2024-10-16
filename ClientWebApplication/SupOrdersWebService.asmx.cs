using System;
using System.Data.SqlClient;
using System.Web.Services;

namespace ClientWebApplication
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SupOrdersWebService : WebService
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
                                "UPDATE OrderTable SET status = @status WHERE OrderId = @orderId", con, transaction);
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
                "SELECT productName, productQty FROM OrderTable WHERE OrderId = @orderId", con, transaction);
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
                        "UPDATE ProductsTable SET Qauntity = Qauntity - @orderQty WHERE ItemName = @productName", con, transaction);
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
