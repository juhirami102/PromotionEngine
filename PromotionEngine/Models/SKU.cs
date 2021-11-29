using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class SKU
    {
        public string SkuId { get; set; }
        public int Quantity { get; set; }
        public SKU(string sku,int quantity)
        {
            SkuId = sku;
            Quantity = quantity;          
        }
    }
}
