using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerceTools.Data.Services
{
    public class TierPricingImportService
    {
        public Data.Models.NopCommerceDataContext dbContext;
        public TierPricingImportService(Data.Models.NopCommerceDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public static bool ValidateTierPricingCSV(List<string> fileData)
        {
            var success = false;

            if (fileData.Count() > 0)
            {
                //check the first line and see if it matches the expected format...
                //sku,MinQty,Price
                foreach (var s in fileData)
                {
                    var splitData = fileData[0].Split(',');
                    if (splitData.Count() == 3)
                    {
                        if (string.IsNullOrEmpty(splitData[0]))
                        {
                            var minQty = -1;
                            if (int.TryParse(splitData[1], out minQty))
                            {
                                decimal price = 0.00M;
                                if (decimal.TryParse(splitData[2], out price))
                                {
                                    success = true;
                                }
                            }
                        }
                    }
                }
            }

            return success;
        }

        public List<Models.TierPricingImportModel> ParseCSVData(List<string> csvData)
        {
            var outData = new List<Models.TierPricingImportModel>();

            foreach (var record in csvData)
            {
                var splData = record.Split(',');
                outData.Add(new Models.TierPricingImportModel() {
                    Sku = splData[0],
                    MinQty = int.Parse(splData[1]),
                    Price = decimal.Parse(splData[2])
                });
            }

            return outData;
        }

        public void ProcessTierPricingForItem(List<Models.TierPricingImportModel> items)
        {
            //find the product id for item from the database
            var productId = dbContext.Products.FirstOrDefault(x => x.Sku.ToLower() == items.FirstOrDefault().Sku.ToLower()).Id;

            //remove the old pricing data for the sku
            dbContext.TierPrices.RemoveRange(dbContext.TierPrices.Where(x => x.ProductId == productId));

            dbContext.SaveChanges();

            //process the new records
            foreach (var item in items)
            {
                dbContext.TierPrices.Add(new Models.TierPrice() {
                    Price = item.Price,
                    ProductId = productId,
                    Quantity = item.MinQty
                });
            }
            dbContext.SaveChanges();
        }
    }
}