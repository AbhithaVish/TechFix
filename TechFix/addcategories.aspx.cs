using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;

namespace TechFix
{
    public partial class addcategories : System.Web.UI.Page
    {
        CategoryServiceReference.CategoryWebServiceSoapClient obj =
            new CategoryServiceReference.CategoryWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCategoryId.Text = obj.AutoCategoryId();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Length > 50) 
            {
                lbltext.Text = "Category Name too long. Maximum length is 50 characters.";
                return;
            }

            string value = obj.insertCategory(txtCategoryId.Text, txtCategoryName.Text);

            int norecord;
            if (Int32.TryParse(value, out norecord))
            {
                if (norecord > 0)
                {
                    lbltext.Text = "Record Successfully Added";
                }
                else
                {
                    lbltext.Text = "Record Failed to Add";
                }
            }
            else
            {
                lbltext.Text = "Unexpected return value: " + value;
            }
        }
    }
    }
