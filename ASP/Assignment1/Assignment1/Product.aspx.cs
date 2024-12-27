
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Products
{
    public partial class Products : System.Web.UI.Page
    {
        // Define a dictionary to store product details (name, image URL, price)
        private static readonly Dictionary<string, (string ImageUrl, decimal Price)> products = new Dictionary<string, (string, decimal)>
        {
            { "TV", ("~/images/TV.jpg", 99999) },
            { "Fridge", ("~/images/fridge.jpg", 48999) },
            { "Sofa", ("~/images/Sofa.jpg", 26999) }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.DataSource = products.Keys;
                ddlProducts.DataBind();
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedProduct = ddlProducts.SelectedValue;

            if (products.TryGetValue(selectedProduct, out var productInfo))
            {

                imgProduct.ImageUrl = productInfo.ImageUrl;
                lblPrice.Text = "";
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {

            string selectedProduct = ddlProducts.SelectedValue;

            if (products.TryGetValue(selectedProduct, out var productInfo))
            {

                lblPrice.Text = $"Price: ₹{productInfo.Price}";
            }
        }
    }
}
