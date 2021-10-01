using System;

namespace ShoppingCard.Core.Shared
{
    public record Money
    {
        public decimal Value { get; private set; }

        protected Money(decimal amount)
        {
            this.Value = amount;
        }

        public static Money FromDecimal(decimal amount)
        {
            return new Money(amount);
        }

        public static Money FromDouble(double amount)
        {
            return new Money(Convert.ToDecimal(amount));
        }

        public static Money FromInt(int amount)
        {
            return new Money(amount);
        }

        public static Money fromString(string amount)
        {
            return new Money(decimal.Parse(amount));
        }

        public static implicit operator decimal(Money self) => self.Value;

        public override string ToString() => Value.ToString();
    }
}
