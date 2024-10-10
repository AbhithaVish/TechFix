using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TechFix
{
    public partial class adminViewProducts : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
                con.Open();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error connecting to DB: " + ex.Message;
            }

            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT productID, productName, productDesc, productPrice FROM ProductsTable", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                productRepeater.DataSource = dt;
                productRepeater.DataBind();
            }
            catch (Exception ex)
            {
                lblText.Text = "Error loading products: " + ex.Message;
            }
        }

        protected void ViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("cart.aspx");
        }

        protected void productRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int productID = Convert.ToInt32(e.CommandArgument);

                // Add product to session/cart
                DataTable cart;
                if (Session["Cart"] == null)
                {
                    cart = new DataTable();
                    cart.Columns.Add("productID", typeof(int));
                    cart.Columns.Add("productName", typeof(string));
                    cart.Columns.Add("productPrice", typeof(decimal));
                }
                else
                {
                    cart = (DataTable)Session["Cart"];
                }

                try
                {
                    // Use parameters to avoid SQL injection
                    SqlCommand cmd = new SqlCommand("SELECT productID, productName, productPrice FROM ProductsTable WHERE productID = @productID", con);
                    cmd.Parameters.AddWithValue("@productID", productID);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        DataRow row = cart.NewRow();
                        row["productID"] = dr["productID"];
                        row["productName"] = dr["productName"];
                        row["productPrice"] = dr["productPrice"];
                        cart.Rows.Add(row);
                    }
                    dr.Close();
                    Session["Cart"] = cart;
                }
                catch (Exception ex)
                {
                    lblText.Text = "Error adding product to cart: " + ex.Message;
                }
            }
        }
    }
}
