<Query Kind="Expression">
  <Connection>
    <ID>efa11166-6a1c-4ed4-9fe5-e42343a0ba7f</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Practice questions - do each one in a separate LinqPad query.

//A) List all the customer company names for those with more than 5 orders.
from buyer in Customers
where buyer.Orders.Count() >5
select buyer.CompanyName

//B) Get a list of all the region names
from place in Regions
select place.RegionDescription
//C) Get a list of all the territory names
from place in Territories
select place.TerritoryDescription

//D) List all the regions and the number of territories in each region
from place in Regions
select new
{
	Region = place.RegionDescription,
	TerritoryCount = place.Territories.Count()
}
//E) List all the region and territory names in a "flat" list
from place in Territories
select new
{
	Region = place.Region.RegionDescription,
	Territory = place.TerritoryDescription
}

//F) List all the region and territory names as an "object graph"
//   - use a nested query
from place in Regions
select new
{
	Region = place.RegionDescription,
	Territories = from area in place.Territories
					select area.TerritoryDescription
}

//G) List all the product names that contain the word "chef" in the name.
from item in Products
where item.ProductName.Contains("chef")
select item.ProductName

//H) List all the discontinued products, specifying the product name and unit price.
from item in Products
where item.Discontinued
select new
{
	item.ProductName,
	item.UnitPrice
}


//I) List the company names of all Suppliers in North America (Canada, USA, Mexico)
from vendor in Suppliers
where vendor.Address.Country == "Canada" 
|| vendor.Address.Country == "USA"
|| vendor.Address.Country == "Mexico"
select vendor.CompanyName

