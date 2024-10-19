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
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            con.Open();
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtClientName.Text) ||
                    string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    lblText.Text = "All fields are required.";
                    return;
                }

                // Insert data into CusTable
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO CusTable (username, clientName, age, address, password) " +
                    "VALUES (@username, @clientName, @age, @address, @password)", con);

                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@clientName", txtClientName.Text);
                cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text)); // Ensure age is converted to int
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text); // Consider hashing the password before storing it

                int NoRows = cmd.ExecuteNonQuery();

                if (NoRows > 0)
                {
                    lblText.Text = "Registration successful!";
                    txtUsername.Text = "";
                    txtClientName.Text = "";
                    txtAge.Text = "";
                    txtAddress.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    lblText.Text = "Registration failed.";
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error inserting data: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CusLogin.aspx");
        }
    }
}