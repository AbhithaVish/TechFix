using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ClientWebApplication
{
    /// <summary>
    /// Summary description for CusLoginWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CusLoginWebService : System.Web.Services.WebService
    {
        private SqlConnection getConnection()
        {
            SqlConnection sqlCon = null;
            try
            {
                sqlCon = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
                sqlCon.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error connecting to Db: " + ex.Message);
            }
            return sqlCon;
        }

        [WebMethod]
        public bool ValidateUser(string username, string password)
        {
            try
            {
                using (SqlConnection con = getConnection())
                {
                    string query = "SELECT COUNT(*) FROM CusTable WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int userCount = (int)cmd.ExecuteScalar();
                        return userCount > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
