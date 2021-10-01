using ShoppingCard.Core.Exceptions;

namespace ShoppingCard.Core.Shared
{
    public class Price
    {
        public Money Value { get; private set;  }

        public Price(Money amount)
        {
            IsValid(amount.Value);

            Value = amount;
        }

        private bool IsValid(decimal amount)
        {
            if (amount < 0)
                throw new ProductExceptions.InvalidPriceException("Price cannot be negative");

            return true;
        }

        public static implicit operator decimal(Price self) => self.Value;

        public static implicit operator Price(decimal value)
            => new Price(Money.FromDecimal(value));

        public override string ToString() => Value.ToString();
    }
}
