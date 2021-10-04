using System;

namespace ShoppingCard.Core.Shared
{
    public record CardId
    {
        public Guid Value { get; private set; }

        public CardId(Guid id)
        {
            Value = id;
        }

        public static implicit operator Guid(CardId self) => self.Value;

        public static implicit operator CardId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString();
    }
}
