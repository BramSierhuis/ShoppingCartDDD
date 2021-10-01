using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Exceptions
{
    public static class ProductExceptions
    {
        public class InvalidEanException : Exception
        {
            public InvalidEanException(string message) : base($"Invalid ean: {message}")
            {
            }
        }

        public class InvalidPriceException : Exception
        {
            public InvalidPriceException(string message) : base($"Invalid price: {message}")
            {
            }
        }

        public class InvalidQuantityException: Exception
        {
            public InvalidQuantityException(string message) : base($"Invalid quantity: {message}")
            {
            }
        }
    }
}
