using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class supplierProductAddWebForm : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("data source=localhost\\SQLEXPRESS;initial catalog=TechFix3.0;Integrated Security=True");
            con.Open();

            if (!IsPostBack)
            {
                getCategoryName(); // Only fetch categories as the supplier dropdown is no longer needed
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                decimal productPrice;
                int productQty;

                if (!decimal.TryParse(txtProdPrice.Text, out productPrice))
                {
                    lblText.Text = "Invalid product price.";
                    return;
                }

                if (!int.TryParse(txtProdQty.Text, out productQty))
                {
                    lblText.Text = "Invalid product quantity.";
                    return;
                }

                // Get the logged-in username from the session
                string username = Session["username"] != null ? Session["username"].ToString() : string.Empty;

                if (string.IsNullOrEmpty(username))
                {
                    lblText.Text = "You must be logged in to add products.";
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO ProductsTable (productName, productPrice, productQty, productDesc, username, categoryId) VALUES (@productName, @productPrice, @productQty, @productDesc, @username, @categoryId)", con);

                cmd.Parameters.AddWithValue("@productName", txtProdName.Text);
                cmd.Parameters.AddWithValue("@productPrice", productPrice);
                cmd.Parameters.AddWithValue("@productQty", productQty);
                cmd.Parameters.AddWithValue("@productDesc", txtProdDesc.Text);
                cmd.Parameters.AddWithValue("@username", username); // Use the session username directly
                cmd.Parameters.AddWithValue("@categoryId", dlCategory.SelectedValue);

                int NoRows = cmd.ExecuteNonQuery();

                if (NoRows > 0)
                {
                    lblText.Text = "Record added successfully!";
                    txtProdName.Text = "";
                    txtProdPrice.Text = "";
                    txtProdQty.Text = "";
                    txtProdDesc.Text = "";
                }
                else
                {
                    lblText.Text = "Record was not added.";
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

        private void getCategoryName()
        {
            SqlCommand cmd = new SqlCommand("SELECT categoryName, categoryId FROM CategoryTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dlCategory.DataSource = dt;
            dlCategory.DataTextField = "categoryName";
            dlCategory.DataValueField = "categoryId";
            dlCategory.DataBind();
            dlCategory.Items.Insert(0, new ListItem("Select category", ""));
        }

        protected void btnAddProducts_Click1(object sender, EventArgs e)
        {
            Response.Redirect("supplierAddProducts.aspx");
        }

        protected void btnviewProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplierViewProducts.aspx");
        }

        protected void btnOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupOrders.aspx");
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupplerHome.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SupplierLogin.aspx");
        }
    }
}
