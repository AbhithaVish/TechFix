using System;
using System.Data;
using System.Data.SqlClient;
using System.Data;
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
                getSupplierName();
                getCategoryName();
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

                SqlCommand cmd = new SqlCommand("INSERT INTO ProductsTable (productName, productPrice, productQty, productDesc, username, categoryId) VALUES (@productName, @productPrice, @productQty, @productDesc, @username, @categoryId)", con);

                cmd.Parameters.AddWithValue("@productName", txtProdName.Text);
                cmd.Parameters.AddWithValue("@productPrice", productPrice);
                cmd.Parameters.AddWithValue("@productQty", productQty);
                cmd.Parameters.AddWithValue("@productDesc", txtProdDesc.Text);
                cmd.Parameters.AddWithValue("@username", dlSupplier.SelectedValue);
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

        private void getSupplierName()
        {
            SqlCommand cmd = new SqlCommand("SELECT name, username FROM SuppliersTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dlSupplier.DataSource = dt;
            dlSupplier.DataTextField = "name";
            dlSupplier.DataValueField = "username";
            dlSupplier.DataBind();
            dlSupplier.Items.Insert(0, new ListItem("Select supplier", ""));
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
    }
}
