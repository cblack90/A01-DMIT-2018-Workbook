<Query Kind="Expression">
  <Connection>
    <ID>271f749e-79ef-4a37-bb76-edb28fc7e82e</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

// - Filter on partial name
// List employees who have an "an" in their first name
// returns IOrderedQueryable TODO: Look it up!
from person in Employees
where person.FirstName.Contains("an")
select person