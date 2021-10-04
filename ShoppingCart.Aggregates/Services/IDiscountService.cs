namespace ShoppingCart.Aggregates.Services
{
    public interface IDiscountService
    {
        bool IsValidCode(string code);
    }
}
