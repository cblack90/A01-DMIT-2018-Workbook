<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

/*
-Supplier:
    -Company Name
    -Contact Name
    -Phone Number
    -Product Summary:
         -Product Name
         -Category Name
         -Unit Price
         -Quantity/Unit
		 */
from company in Suppliers
select new
{
	CompanyName = company.CompanyName,
	ContactName = company.ContactName,
	PhoneNumber = company.Phone,
	ProductSummary = from item in company.Products
					 select new
					 {
					 	ProductName = item.ProductName,
						CategoryName = item.Category.CategoryName,
						UnitPrice = item.UnitPrice,
						QuantityPerUnit = item.QuantityPerUnit
					 }
}