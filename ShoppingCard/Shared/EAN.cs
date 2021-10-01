using ShoppingCard.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Shared
{
    public record EAN
    {
        public long Value { get; private set;  }
        public EAN(long ean)
        {
            if (ean % 1 != 0)
                throw new ProductExceptions.InvalidEanException("EAN cannot contain decimal places");
            if (ean.ToString().Length > 13)
                throw new ProductExceptions.InvalidEanException("EAN cannot be longer than 13 characters");
            if (ean.ToString().Length < 13)
                throw new ProductExceptions.InvalidEanException("EAN cannot be shorter than 13 characters");

            Value = ean;
        }

        public static implicit operator long(EAN self) => self.Value;

        public static implicit operator EAN(long value)
            => new (value);

        public override string ToString() => Value.ToString();
    }
}
