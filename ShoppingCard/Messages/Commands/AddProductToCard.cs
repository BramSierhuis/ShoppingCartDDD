using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Messages.Commands
{
    public class AddProductToCard
    {
        public long Ean { get; set; }
        public int Quantity { get; set; }
    }
}
