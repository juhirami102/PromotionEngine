namespace PromotionEngine.Models
{
    public interface IPromotionStrategy
    {
        decimal GetBestPrice(int quantity);
        void Print();
    }
}
