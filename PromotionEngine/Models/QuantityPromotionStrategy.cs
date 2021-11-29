using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    /// <summary>
    /// Startegy for Quantity wise discount
    /// </summary>
    public class QuantityPromotionStrategy : IPromotionStrategy
    {
        private decimal _priceForOne;
        private decimal _priceForMultiple;
        private int _discountQuantity;       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="priceForOne">Price for One item</param>
        /// <param name="priceForMultiple">Price for Multiple items purchased</param>
        /// <param name="discountQuantity">Discount applicable if purchased above</param>
        public QuantityPromotionStrategy(decimal priceForOne, decimal priceForMultiple, int discountQuantity)
        {
            _priceForOne = priceForOne;
            _priceForMultiple = priceForMultiple;
            _discountQuantity = discountQuantity;

            
        }
        

        /// <summary>
        /// Get Price for Quantity wise discount
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public decimal GetBestPrice(int quantity)
        {
            if (quantity == 0) return 0;          

            decimal result = 0;            
            while (quantity >= _discountQuantity)
            {
                result = result + _priceForMultiple;
                quantity = quantity - _discountQuantity;
            }

            return result + (_priceForOne * quantity);
        }

        public void Print()
        {
            Console.WriteLine($"QuantityPromotionStrategy applied : PriceForOne:{_priceForOne}, PriceForMultiple:{_priceForMultiple} and DicountQuantity:{_discountQuantity}");
        }
    }
}
