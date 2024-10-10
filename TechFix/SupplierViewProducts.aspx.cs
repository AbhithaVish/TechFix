using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace TechFix
{
    public partial class SupplierViewProducts : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session["username"] == null)
            {
                Response.Redirect("SupplierLogin.aspx"); // Redirect to login page if not logged in
                return;
            }

            // Display the username (optional)
            lblUsername.Text = "Welcome, " + Session["username"].ToString();

            try
            {
                con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
                con.Open();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error connecting to the database: " + ex.Message;
            }

            if (!IsPostBack)
            {
                LoadCustomerData();
            }
        }

        private void LoadCustomerData()
        {
            try
            {
                string username = Session["username"].ToString(); // Get the username from session

                // Use the correct column names
                SqlCommand cmd = new SqlCommand("SELECT ItemId, ItemName, Decription, Price, Qauntity, CategoryName, Warranty FROM Product_Supplier WHERE username = @Username", con);
                cmd.Parameters.AddWithValue("@Username", username); // Parameterize the query to prevent SQL injection

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Bind data to GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error loading data: " + ex.Message;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selected index change if needed
        }
    }
}
