using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindSystem.DataModels
{
    public class SupplierProduct
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<SupplierProductSummary> SupplierProductSummary { get; set; }
    }
}
