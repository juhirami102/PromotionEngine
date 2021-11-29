using PromotionEngine.Bussiness;
using PromotionEngine.Constants;
using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] _matches = new[] { "A", "B", "C", "D", "X" };
            string s;
            string val;
            var lstSkus = new List<SKU>();

            try
            {

                Console.WriteLine("************************ Welcome to Big Super Mart! ************************ ");
                Console.WriteLine("*****************************************************************************");

                var todaysPromotions = SetupTodaysPromotions();
                var promotions = new ManagePromotion(todaysPromotions);
                foreach (var p in todaysPromotions)
                {
                    Console.WriteLine($"Promotions for {p.Key.SkuId} ");
                    p.Value.Print();
                }
                Console.WriteLine("*****************************************************************************");
                while (true)
                {
                    Console.WriteLine("Please enter  A --> To Buy A \n");
                    Console.WriteLine("Please enter  B --> To Buy B \n");
                    Console.WriteLine("Please enter  C --> To Buy C \n");
                    Console.WriteLine("Please enter  D --> To Buy D \n");
                    Console.WriteLine("Please enter  X --> Exit or CheckOut \n");
                    s = Console.ReadLine().ToString().ToUpper();
                    if (_matches.Contains(s))
                    {
                        if (s.ToString().ToUpper().Equals("X"))
                            break;
                        Console.WriteLine("\nYour input: {0}", s);
                        Console.WriteLine("\nPlease enter quantity to buy\n");
                        val = Console.ReadLine();
                        int q = Convert.ToInt32(val);
                        Console.WriteLine("\nYour input: {0}", q);
                        lstSkus.Add(new SKU(s, q));

                    }
                    else
                        Console.WriteLine(" ********************* INVALID ENTRY ********************* \n\n");

                }
                var price = promotions.Compute(lstSkus);
                Console.WriteLine($"\nTotal Cart Value is : {price} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered : {ex.Message} ");
            }

            Console.ReadKey();
        }

        private static Dictionary<SKU, IPromotionStrategy> SetupTodaysPromotions()
        {
            return new Dictionary<SKU, IPromotionStrategy>()
            {
                { new SKU(SKUList.A,1), new QuantityPromotionStrategy(PriceForOne.PriceForA, PriceForMultiple.PriceForA, 3) },
                { new SKU(SKUList.B,1), new QuantityPromotionStrategy(PriceForOne.PriceForB, PriceForMultiple.PriceForB, 2) },
                { new SKU(SKUList.C,1), new BaseStrategy(PriceForOne.PriceForC) } ,
                { new SKU(SKUList.D,1), new BaseStrategy(PriceForOne.PriceForD) }
            };
        }
    }
}
