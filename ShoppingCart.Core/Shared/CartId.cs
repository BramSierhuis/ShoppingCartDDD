using System;

namespace ShoppingCart.Core.Shared
{
    public record CartId
    {
        public Guid Value { get; private set; }

        public CartId(Guid id)
        {
            Value = id;
        }

        public static implicit operator Guid(CartId self) => self.Value;

        public static implicit operator CartId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString();
    }
}
