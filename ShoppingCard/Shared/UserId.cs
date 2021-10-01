using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Shared
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
