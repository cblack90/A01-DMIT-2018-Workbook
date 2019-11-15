using System;
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
            throw new NotImplementedException();
            //TODO: Validation
            /*
             * Validation:
                OrderID must be valid
                ShippingDirections is required (cannot be null)
                List<ShippedItem> cannot be empty/null
                The products must be on the order AND items that this supplier provides
                Quantities must be great than zero and less than or equal to the quantity outstanding
                Shipper must exist
                Freight charge must be either null (no charg) or > $0.00
             */
            //TODO: Processing
            /*
             * Processing (tables/data that must be uptated/inserted/deleted/whatever)
               Create new Shipment
               Add all manifest items
               Check if order is complete; if so, update Order.Shipped
             * */
        }
        #endregion

    }
}
