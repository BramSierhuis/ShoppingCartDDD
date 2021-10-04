using System;

namespace ShoppingCard.Core.Shared
{
    public record ProductId
    {
        public Guid Value { get; private set; }

        public ProductId(Guid id)
        {
            Value = id;
        }

        public static implicit operator Guid(ProductId self) => self.Value;

        public static implicit operator ProductId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString();
    }
}
