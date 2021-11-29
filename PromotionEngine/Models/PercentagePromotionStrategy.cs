using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    /// <summary>
    /// Startegy for discount pricing
    /// </summary>
    public class PercentagePromotionStrategy : IPromotionStrategy
    {
        private int _percentDiscount;
        private decimal _price;

        public PercentagePromotionStrategy(decimal price, int percentDiscount)
        {
            if (price < 0) throw new Exception($"{nameof(price)}:{price} - should be greater than Zero");
            if (percentDiscount > 100 || percentDiscount <0) throw new Exception($"{nameof(percentDiscount)}:{percentDiscount} - should be valid percentage value");

            _percentDiscount = percentDiscount;
            _price = price;

            
        }
        public decimal GetBestPrice(int quantity)
        {
            if (quantity < 0) throw new Exception($"{nameof(quantity)}:{quantity} - should be greater than Zero");
            return (_price - (_price / _percentDiscount)) * quantity;
        }

        public void Print()
        {
            Console.WriteLine($"PercentagePromotionStrategy applied : %Discount:{_percentDiscount} and Price:{_price}");
        }
    }
}
