<Query Kind="Program">
  <Connection>
    <ID>3f9abe4b-26fe-4a15-875a-aed17b15457c</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	var output = ListShippers();
	output.Dump();
}

// Define other methods and classes here
 public class ShipperSelection
    {
        public int ShipperID { get; set; }
        public string Shipper { get; set; }
    }
        public List<ShipperSelection> ListShippers()
        {
            //throw new NotImplementedException();
            //TODO: Get all the shippers form the Db
			var result = from shipper in Shippers
						orderby shipper.CompanyName
						select new ShipperSelection
						{
							ShipperID = shipper.ShipperID,
							Shipper = shipper.CompanyName
						};
			return result.ToList();
        }
