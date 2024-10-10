using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ClientWebApplication
{
    /// <summary>
    /// Summary description for CategoryWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CategoryWebService : System.Web.Services.WebService
    {
        SqlConnection sqlCon = null;
        public SqlConnection getConnection()
        {
            try
            {
                sqlCon = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
                sqlCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Db" + ex);
            }
            return sqlCon;
        }

        [WebMethod]
        public string AutoCategoryId()
        {
            string CategoryId = null;
            try
            {
                getConnection();
                // Modify the query to get the highest CategoryId
                SqlCommand cmd = new SqlCommand("SELECT MAX(categoryId) FROM CategoryTable", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                string id = "";

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        id = dr[0].ToString(); 
                    }

                    if (!string.IsNullOrEmpty(id))
                    {
                        string idString = id.Substring(1); 
                        int CTR = Int32.Parse(idString);   

                        if (CTR >= 1 && CTR < 9)
                        {
                            CTR = CTR + 1; 
                            CategoryId = "C00" + CTR;  
                        }
                        else if (CTR >= 10 && CTR < 99)
                        {
                            CTR = CTR + 1;
                            CategoryId = "C0" + CTR;  
                        }
                        else if (CTR >= 100)
                        {
                            CTR = CTR + 1;
                            CategoryId = "C" + CTR;  
                        }
                    }
                    else
                    {
                        CategoryId = "C001";
                    }
                }
                else
                {
                    
                    CategoryId = "C001";
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                CategoryId = ex.ToString();
            }
            return CategoryId;
        }


        [WebMethod]
        public string insertCategory(string categoryId, string categoryName)
        {
            int NoRows = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("insert into CategoryTable values ('" +
                                   categoryId + "','" + categoryName + "');", sqlCon);

                NoRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return NoRows.ToString();
        }

    }
}
