using PromotionEngine.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    /// <summary>
    /// Base strategy for getting best price
    /// </summary>
    public class BaseStrategy : IPromotionStrategy
    {
        private decimal _price;
        bool containSKU1 = false, containSKU2 = false;

        public BaseStrategy(decimal price)
        {

            if (price < 0) throw new Exception($"{nameof(price)}:{price} - should be greater than Zero");
            _price = price;

            
        }
        public decimal GetBestPrice(int quantity)
        {
            if (quantity<0) throw new Exception($"{nameof(quantity)}:{quantity} - should be greater than Zero");
            return _price * quantity;
        }

        public void Print()
        {
            Console.WriteLine($"BaseStrategy applied: No Discounts!");
        }
    }
}
