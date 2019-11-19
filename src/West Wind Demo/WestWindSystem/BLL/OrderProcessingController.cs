﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
    [DataObject]
    public class OrderProcessingController
    {
        #region Queries
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<OutStandingOrder> LoadOrders(int supplierID)
        {
            //TODO: Implement this method with the following
            /*
             * Validation:
                Make sure the supplier ID exists, otherwise throw an exception
                [Advanced:] Make sure the logged-in user works for the identified supplier.
                Query for outstanding orders, getting data from the following tables:
                TODO: List table names
             */
             using (var context = new WestWindContext())//Using my DAL object
            {
                //Validation
                var supplier = context.Suppliers.Find(supplierID);
                if (supplier == null)
                    throw new Exception("Invalid supplier, unable to load orders");
                //Processing
                var result =
                from sale in context.Orders
                where !sale.Shipped && sale.OrderDate.HasValue
                select new OutStandingOrder
                {
                    OrderID = sale.OrderID,
                    ShipToName = sale.ShipName,
                    OrderDate = sale.OrderDate.Value,
                    RequiredBy = sale.RequiredDate.Value,
                    OutstandingItems = from item in sale.OrderDetails
                                       where item.Product.SupplierID == supplierID
                                       select new OrderItem
                                       {
                                           ProductID = item.ProductID,
                                           ProductName = item.Product.ProductName,
                                           Qty = item.Quantity,
                                           QtyPerUnit = item.Product.QuantityPerUnit,
                                           //TODO: Figure out the Outstanding quantity
                                           //Outstanding = (from ship in item.Order.Shipments
                                           //from shipItem in ship.ManifestItems
                                           //where shipItem.ProductID == item.ProductID
                                           //select shipItem.ShipQuantity).Sum()
                                       },
                    FullShippingAddress = //TODO: how to use sale.ShipAddressID,
                                            sale.Customer.Address.Street + Environment.NewLine +
                                            sale.Customer.Address.City + ", " +
                                            sale.Customer.Address.Region + Environment.NewLine +
                                            sale.Customer.Address.Country + " " +
                                            sale.Customer.Address.PostalCode,
                    Comments = sale.Comments
                };
                    return result.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ShipperSelection> ListShippers()
        {
            using(var context = new WestWindContext())
            {
                var result = from shipper in context.Shippers
                             orderby shipper.CompanyName
                             select new ShipperSelection
                             {
                                 ShipperID = shipper.ShipperID,
                                 Shipper = shipper.CompanyName
                             };
                return result.ToList();
            }
            
        }
        #endregion
        #region Commands
        public void ShipOrder(int orderID, ShippingDirections shipping, List<ShippedItem> items)
        {
            using(var context = new WestWindContext())
            {
                //TODO: Validation
                //a) OrderID must be valid
                var existingOrder = context.Orders.Find(orderID);
                if (existingOrder == null)
                    throw new Exception("Order does no exist");
                if (existingOrder.Shipped)
                    throw new Exception("This order has already been completed");
                if (!existingOrder.OrderDate.HasValue)
                    throw new Exception("This order is not ready to be shipped (no order date has been specified)");

                //b)ShippingDirections is required (cannot be null)
                if (shipping == null)
                    throw new Exception("Now shipping details provided");
                //c) Shipper must exist
                var shipper = context.Shippers.Find(shipping.ShipperID);
                if (shipper == null)
                    throw new Exception("Invalid shipper ID");
                //d) Freight charge must be either null (no charg) or > $0.00
                //TODO: Q- Should I just convert a $0 charge to a null?
                if (shipping.FreightCharge.HasValue && shipping.FreightCharge <= 0)
                    throw new Exception("Freight charge must be either a positive value or no charge");
                //e)List<ShippedItem> cannot be empty/null
                if (items == null || !items.Any())
                    throw new Exception("No products identified for shipping");
                //f) The products must be on the order 
                foreach(var item in items)
                {
                    if (item == null) throw new Exception("Blank items listed in the products to be shipped");
                    if (!existingOrder.OrderDetails.Any(x => x.ProductID.ToString() == item.Product))
                        throw new Exception($"The product {item.Product} does not exist on the order");
                    //f-2)AND items that this supplier provides
                    //TODO: g) Quantities must be great than zero and less than or equal to the quantity outstanding
                }

                //TODO: Processing
                /*
                 * Processing (tables/data that must be uptated/inserted/deleted/whatever)
                   Create new Shipment
                   Add all manifest items
                   Check if order is complete; if so, update Order.Shipped
                 * */

            }

        }
        #endregion

    }
}
