<Query Kind="Expression">
  <Connection>
    <ID>1d4af5d7-0e29-4a58-9a24-4410b6173416</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Orders.Max(sale => sale.OrderDate).Value.Month
 
from sale in Orders
where sale.OrderDate.Value.Month == 5
	&& sale.OrderDate.Value.Year == 2018
select sale
 
from sale in Orders
where sale.OrderDate.Value.Month == 5
	&& sale.OrderDate.Value.Year == 2018
select new
{
	Customer = sale.Customer.CompanyName,
	ResponseTime = sale.RequiredDate.Value - sale.OrderDate.Value,
	PaymentDueOn = sale.PaymentDueDate,
	FirstPayment = sale.Payments.First().PaymentDate,
	PaymentResponseTime = sale.Payments.First().PaymentDate - sale.PaymentDueDate.Value
	
}	