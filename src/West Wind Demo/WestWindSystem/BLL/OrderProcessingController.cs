using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
    public class OrderProcessingController
    {
        public List<OutStandingOrder> LoadOrders(int supplierID)
        {
            throw new NotImplementedException();
            //TODO: Implement this method with the following
            /*
             * Validation:
                Make sure the supplier ID exists, otherwise throw an exception
                [Advanced:] Make sure the logged-in user works for the identified supplier.
                Query for outstanding orders, getting data from the following tables:
                TODO: List table names
             */
        }
        public List<ShipperSelection> ListShippers()
        {
            throw new NotImplementedException();
            //TODO: Get all the shippers form the Db
        }

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

    }
}
