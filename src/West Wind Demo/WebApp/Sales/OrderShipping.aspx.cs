﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security; //for Settings Class
using WestWindSystem.BLL;
using WestWindSystem.DataModels;

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

        protected void CurrentOrders_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "Ship")
            {
                //Gather information from the form to send to the BLL for shipping
                //ShipOrder(int orderID, ShippingDirections shipping, List<ShippedItem> items)
                int orderID = 0;
                Label ordIdLabel = e.Item.FindControl("OrderIdLabel") as Label; //safe case the control object to a Label object
                if (ordIdLabel != null)
                    orderID = int.Parse(ordIdLabel.Text);

                ShippingDirections shipInfo = new ShippingDirections(); //blank obj

                DropDownList shipViaDropDown = e.Item.FindControl("ShipperDropDown") as DropDownList;
                if (shipViaDropDown != null) // if I got the control
                    shipInfo.ShipperID = int.Parse(shipViaDropDown.SelectedValue);

                //string trackingNo = "";
                TextBox trackLabel = e.Item.FindControl("TrackingCode") as TextBox;
                if (trackLabel != null)
                    shipInfo.TrackingCode = trackLabel.Text;

                decimal freight;
                TextBox freightLabel = e.Item.FindControl("FreightCharge") as TextBox;
                if (freightLabel != null && decimal.TryParse(freightLabel.Text, out freight))
                    shipInfo.FreightCharge = freight;

                List<ShippedItem> goods = new List<ShippedItem>();
                GridView gv = e.Item.FindControl("ProductsGridView") as GridView;
                if(gv != null)
                {
                    foreach(GridViewRow row in gv.Rows)
                    {
                        //get product id and ship qty
                        short quantity;
                        HiddenField prodID = row.FindControl("ProductID") as HiddenField;
                        TextBox qty = row.FindControl("ShipQuantity") as TextBox;
                        if(prodID != null && qty != null && short.TryParse(qty.Text, out quantity))
                        {
                            ShippedItem item = new ShippedItem
                            {
                                Product = prodID.Value,
                                Quantity = quantity
                            };
                            goods.Add(item);
                        }

                    }
                }
                MessageUserControl.TryRun(() =>
                {
                    var controller = new OrderProcessingController();
                    controller.ShipOrder(orderID, shipInfo, goods);
                }, "Order shipment Recorded","The products identified as shipped are recorded in the database");
                
            }
        }
    }
}