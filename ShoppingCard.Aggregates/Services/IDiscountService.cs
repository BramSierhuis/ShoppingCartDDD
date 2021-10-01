namespace ShoppingCard.Aggregates.Services
{
    public interface IDiscountService
    {
        bool IsValidCode(string code);
    }
}
