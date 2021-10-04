using ShoppingCart.Aggregates.Services;

namespace ShoppingCart
{
    public class FakeDiscountService : IDiscountService
    {
        public bool IsValidCode(string code)
        {
            if(code.Contains("valid"))
                return true;

            return false;
        }
    }
}
