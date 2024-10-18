using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ClientWebApplication
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class AdminAddProductsWebService : WebService
    {
        private SqlConnection sqlCon = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");

        [WebMethod]
        public string AutoProductId()
        {
            string ProductId = "P001";
            try
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("Select ProductId from CusProductsTable", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    string id = "";
                    while (dr.Read())
                    {
                        id = dr[0].ToString(); // e.g., "P003"
                    }
                    int ctr = int.Parse(id.Substring(1)) + 1;
                    ProductId = ctr < 10 ? $"P00{ctr}" : (ctr < 100 ? $"P0{ctr}" : $"P{ctr}");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                ProductId = ex.Message;
            }
            finally
            {
                sqlCon.Close();
            }
            return ProductId;
        }

        [WebMethod]
        public string AddProduct(string productName, decimal productPrice, int productQty, string productDesc, string username, string categoryId)
        {
            try
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CusProductsTable (productName, productPrice, productQty, productDesc, username, categoryId) VALUES (@productName, @productPrice, @productQty, @productDesc, @username, @categoryId)", sqlCon);

                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@productPrice", productPrice);
                cmd.Parameters.AddWithValue("@productQty", productQty);
                cmd.Parameters.AddWithValue("@productDesc", productDesc);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);

                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "Record added successfully!" : "Record was not added.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
            finally
            {
                sqlCon.Close();
            }
        }

        [WebMethod]
        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            try
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("SELECT categoryName, categoryId FROM CategoryTable", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching categories: " + ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
            return dt;
        }
    }
}
