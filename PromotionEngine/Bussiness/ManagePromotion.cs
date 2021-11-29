using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PromotionEngine.Constants;

namespace PromotionEngine.Bussiness
{
    public class ManagePromotion 
    {
        private Dictionary<SKU, IPromotionStrategy> _strategies;
        bool containSKU1 = false, containSKU2 = false;
        public ManagePromotion(Dictionary<SKU, IPromotionStrategy> strategies)
        {
            _strategies = strategies;
        }
        public decimal Compute(IList<SKU> skus)
        {
            decimal sumTotal = 0;
            foreach (var s in _strategies)
            {
                
                var sku = skus.Where(p => p.SkuId == s.Key.SkuId).ToList();

                if (sku.Count > 0)
                {
                    if (s.Key.ToString() == SKUList.C)
                    {
                        containSKU1 = true;
                    }
                    else if (s.Key.ToString() == SKUList.D)
                    {
                        containSKU2 = true;
                    }
                    var val = s.Value.GetBestPrice(sku.First().Quantity);
                    sumTotal = sumTotal + val;
                    Console.WriteLine($"Best price for SKU:{sku.First().SkuId} and Quantity: {sku.First().Quantity}  = {val}");
                }
                   
                 
            }

            return sumTotal;
        }

    }
}
