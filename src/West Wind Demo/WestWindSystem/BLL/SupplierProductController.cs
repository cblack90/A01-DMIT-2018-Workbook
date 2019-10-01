using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
    public class SupplierProductController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SupplierProduct> ListSupplierProducts()
        {
            using (var context = new WestWindContext())
            {
                // Apply my LinqPad query to this method
                var result = from company in context.Suppliers
                             select new SupplierProduct
                             {
                                 CompanyName = company.CompanyName,
                                 ContactName = company.ContactName,
                                 Phone= company.Phone,
                                 SupplierProductSummary = from item in company.Products
                                                  select new SupplierProductSummary
                                                  {
                                                      ProductName = item.ProductName,
                                                      CategoryName = item.Category.CategoryName,
                                                      UnitPrice = item.UnitPrice,
                                                      QuantityPerUnit = item.QuantityPerUnit
                                                  }
                             };
                return result.ToList();
            }
        }
    }
}
