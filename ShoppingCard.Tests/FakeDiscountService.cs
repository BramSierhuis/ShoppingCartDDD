using ShoppingCard.Aggregates.Services;

namespace ShoppingCard.Services
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
