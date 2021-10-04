using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Core.Exceptions
{
    public class EventStoreExceptions
    {
        public class StreamNotFoundException : Exception
        {
            public StreamNotFoundException(string message) : base($"Stream not found: {message}")
            {
            }
        }
    }
}
