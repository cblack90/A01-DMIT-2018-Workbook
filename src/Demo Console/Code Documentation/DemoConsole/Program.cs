using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var shipInfo = new ShippingDirections();
            ShipOrder(5, shipInfo, null);

        }

        /// <summary>
        /// Processes the order shipment
        /// </summary>
        /// <param name="orderID">The ID of the order being shipped</param>
        /// <param name="shipping">The <see cref="ShippingDirections"/> of the items being shipped></param>
        /// <param name="products"></param>
        static void ShipOrder(int orderID, ShippingDirections shipping, List<ShippedItem> products)
        {

        }
    }

    /// <summary>
    /// Represents information about the shipper and tracking/freight details for shipping an order.
    /// </summary>
    public class ShippingDirections
    {
        /// <summary> Primary Key of Shipper</summary>
        public int ShipperID { get; set; }
        /// <summary> Tracking Code for Checking shipment progress online</summary>
        public string TrackingCode { get; set; }
        /// <summary>
        /// Freight charges that the shipper makes to the supplier
        /// </summary>
        public decimal? FreightCharge { get; set; } //decimal, proper for monetary values.  Nullable, may not be a freight charge for every order
    }
    public class ShippedItem
    {
        public int ProductID { get; set; }
        public int ShipQuantity { get; set; }

    }
}
