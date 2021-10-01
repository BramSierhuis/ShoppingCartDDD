using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Messages.Events
{
    public class ProductNameChanged : IEvent
    {
        public string Name { get; set; }
    }
}
