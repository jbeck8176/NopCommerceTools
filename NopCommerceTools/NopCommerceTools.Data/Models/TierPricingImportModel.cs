using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceTools.Data.Models
{
    public class TierPricingImportModel
    {
        public string Sku { get; set; }
        public int MinQty { get; set; }
        public decimal Price { get; set; }
    }
}
