﻿using ShoppingCart.Core.Exceptions;

namespace ShoppingCart.Core.Shared
{
    public record Quantity
    {
        public int Value { get; private set;  }

        public Quantity(int quantity)
        {
            if (quantity < 1)
                throw new ProductExceptions.InvalidQuantityException("Quantity cannot be lower then 1");

            Value = quantity;
        }

        public static implicit operator int(Quantity self) => self.Value;

        public static implicit operator Quantity(int value)
            => new (value);

        public override string ToString() => Value.ToString();
    }
}
