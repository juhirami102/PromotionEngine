using NUnit.Framework;
using PromotionEngine.Bussiness;
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
            skus.Add(new SKU("A", 2 ));
            var price = handler.Compute(skus);

            Assert.AreEqual(100, price);
        }

        [Test]
        public void Promotion_FiveB_120()
        {
            var handler = new ManagePromotion(promotions);
            var skus = new List<SKU>();
            skus.Add(new SKU("B", 5));
            var price = handler.Compute(skus);

            Assert.AreEqual(120, price);
        }

        [Test]
        public void Promotion_TenC_100()
        {
            var handler = new ManagePromotion(promotions);
            var skus = new List<SKU>();
            skus.Add(new SKU("C", 10));
            var price = handler.Compute(skus);

            Assert.AreEqual(100, price);
        }

        private static Dictionary<SKU, IPromotionStrategy> SetupTodaysPromotions()
        {
            return new Dictionary<SKU, IPromotionStrategy>()
            {
                { new SKU("A",1), new QuantityPromotionStrategy(50, 130, 3) },
                { new SKU("B",1), new QuantityPromotionStrategy(30, 45, 2) },
                { new SKU("C",1), new BaseStrategy(10) }  ,
                 { new SKU("D",1), new BaseStrategy(10) }
            };
        }
    }
}