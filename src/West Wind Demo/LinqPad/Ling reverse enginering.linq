<Query Kind="Expression">
  <Connection>
    <ID>9f795fec-6525-43c5-bbd0-2819df27768a</ID>
    <Server>.</Server>
    <Database>WestWind</Database>
  </Connection>
</Query>

from cat in Categories
select new //ProductCategory
{
 CategoryName = cat.CategoryName,
 Description = cat.Description,
 Picture = cat.Picture.ToImage(),//note: remove .ToImage() for vs2019
 MimeType = cat.PictureMimeType,
 Products = from item in cat.Products
            select new //ProductSummary
            {
                Name = item.ProductName,
                Price = item.UnitPrice,
                Quantity = item.QuantityPerUnit
            }
}