using NUnit.Framework;
using PromotionEngine.Bussiness;
using PromotionEngine.Constants;
using PromotionEngine.Models;
using System.Collections.Generic;

namespace PromotionEngine.Tests
{
    public class Tests
    {
        private Dictionary<SKU, IPromotionStrategy> promotions;
        [SetUp]
        public void Setup()
        {
            promotions = new Dictionary<SKU, IPromotionStrategy>();
            promotions = SetupTodaysPromotions();
        }

        [Test]
        public void Promotion_TwoA_100()
        {
            var handler = new ManagePromotion(promotions);
            var skus = new List<SKU>();
            skus.Add(new SKU(SKUList.A, 2 ));
            var price = handler.Compute(skus);

            Assert.AreEqual(100, price);
        }

        [Test]
        public void Promotion_FiveB_120()
        {
            var handler = new ManagePromotion(promotions);
            var skus = new List<SKU>();
            skus.Add(new SKU(SKUList.B, 5));
            var price = handler.Compute(skus);

            Assert.AreEqual(120, price);
        }

        [Test]
        public void Promotion_TenC_100()
        {
            var handler = new ManagePromotion(promotions);
            var skus = new List<SKU>();
            skus.Add(new SKU(SKUList.C, 10));
            var price = handler.Compute(skus);

            Assert.AreEqual(100, price);
        }

        private static Dictionary<SKU, IPromotionStrategy> SetupTodaysPromotions()
        {
            return new Dictionary<SKU, IPromotionStrategy>()
            {
                { new SKU(SKUList.A,1), new QuantityPromotionStrategy(PriceForOne.PriceForA, PriceForMultiple.PriceForA, 3) },
                { new SKU(SKUList.B,1), new QuantityPromotionStrategy(PriceForOne.PriceForB, PriceForMultiple.PriceForB, 2) },
                { new SKU(SKUList.C,1), new BaseStrategy(PriceForOne.PriceForC) },
                { new SKU(SKUList.D,1), new BaseStrategy(PriceForOne.PriceForD) }
            };
        }
    }
}