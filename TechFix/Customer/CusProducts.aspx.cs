using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechFix.Customer
{
    public partial class CusProducts : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("../CusLogin.aspx");
                return;
            }

            con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT productID, productName, productDesc, productPrice, productQty, username, categoryId FROM CusProductsTable", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                productList.DataSource = dt;
                productList.DataBind();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error loading products: " + ex.Message;
            }
        }

        protected void productList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                string productID = e.CommandArgument.ToString();
                string loggedInUsername = Session["username"].ToString();

                try
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT productID, productName, productPrice, productQty, username AS supplierUsername " +
                        "FROM CusProductsTable WHERE productID = @productID", con);
                    cmd.Parameters.AddWithValue("@productID", productID);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string productName = dr["productName"].ToString();
                        decimal price = Convert.ToDecimal(dr["productPrice"]);
                        string supplierUsername = dr["supplierUsername"].ToString();
                        int availableQty = Convert.ToInt32(dr["productQty"]);

                        TextBox txtqty = (TextBox)e.Item.FindControl("txtqty");
                        int quantity = string.IsNullOrEmpty(txtqty.Text) ? 1 : Convert.ToInt32(txtqty.Text);
                        decimal totalPrice = price * quantity;

                        if (availableQty >= quantity)
                        {
                            InsertIntoCartTable(productID, productName, quantity, price, totalPrice, supplierUsername);
                            UpdateProductQuantity(productID, availableQty - quantity);

                            lblText.Text = "Product added to cart successfully!";
                        }
                        else
                        {
                            lblText.Text = "Insufficient quantity available.";
                        }
                    }
                    else
                    {
                        lblText.Text = "Product not found.";
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    lblText.Text = "Error adding to cart: " + ex.Message;
                }
            }
        }

        private void UpdateProductQuantity(string productID, int newQty)
        {
            string updateQuery = "UPDATE CusProductsTable SET productQty = @newQty WHERE productID = @productID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, con))
            {
                cmd.Parameters.AddWithValue("@newQty", newQty);
                cmd.Parameters.AddWithValue("@productID", productID);
                cmd.ExecuteNonQuery();
            }
        }

        private string GetNextCartId()
        {
            string query = "SELECT RIGHT('000000000' + CAST(ISNULL(MAX(CAST(id AS INT)), 0) + 1 AS VARCHAR), 10) FROM Quotation";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                return cmd.ExecuteScalar().ToString();
            }
        }

        private void InsertIntoCartTable(string productID, string productName, int quantity, decimal price, decimal totalPrice, string supplierUsername)
        {
            string newId = GetNextCartId();

            string query = "INSERT INTO Quotation (id, productID, productName, productQty, price, totalPrice, username) " +
                           "VALUES (@id, @productID, @productName, @productQty, @price, @totalPrice, @supplierUsername)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", newId);
                cmd.Parameters.AddWithValue("@productID", productID);
                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@productQty", quantity);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                cmd.Parameters.AddWithValue("@supplierUsername", supplierUsername);

                cmd.ExecuteNonQuery();
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

        protected void btnCart_Click123(object sender, EventArgs e)
        {
            Response.Redirect("Quotation.aspx");
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Quotation.aspx");
        }
    }
}
