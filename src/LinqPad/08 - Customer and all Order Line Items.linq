<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// List all the customers and the name, qty & unit price of each
// of the items they purchased.
from data in Customers
//  Customer   Customer[]
select new
{
    CompanyName = data.CompanyName,
    Sales = from purchase in data.Orders
            //    Order            Order[]
            from lineItem in purchase.OrderDetails
            // OrderDetail                OrderDetail[]
			//this format allows you to drill down through multiple tables to get to a meaningful select statement
            select new
            {
                Name = lineItem.Product.ProductName,
                Qty = lineItem.Quantity,
                UnitPrice = lineItem.UnitPrice
            }
}