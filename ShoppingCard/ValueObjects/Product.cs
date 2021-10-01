using ShoppingCard.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.ValueObjects
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Price{ get; set; }
        public int Stock { get; set; }
        public EAN Ean { get; set; }
    }
}
