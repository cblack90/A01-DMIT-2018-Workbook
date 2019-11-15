using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security; //for Settings Class

namespace WebApp.Sales
{
    public partial class OrderShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Request.IsAuthenticated || !User.IsInRole(Settings.SupplierRole))
            {
                Response.Redirect("~", true);
            }
            if (!IsPostBack)
            {
                //Load up the info on the supplier
                //TODO: replace hard-coded supplierID with the user's supplierID
                SupplierInfo.Text = "Temp supplier: ID 2";

            }
        }
    }
}