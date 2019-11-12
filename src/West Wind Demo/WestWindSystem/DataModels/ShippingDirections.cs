namespace WestWindSystem.DataModels
{
    public class ShippingDirections
    {
        public int ShipperID { get; set; }
        public string TrackingCode { get; set; }
        public decimal? FreightCharge { get; set; } //decimal, proper for monetary values.  Nullable, may not be a freight charge for every order
    }
}
