using System;

namespace ShoppingCart.Core.Shared
{
    public record UserId
    {
        public Guid Value { get; private set; }

        public UserId(Guid id)
        {
            Value = id;
        }

        public static implicit operator Guid(UserId self) => self.Value;

        public static implicit operator UserId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString();
    }
}
