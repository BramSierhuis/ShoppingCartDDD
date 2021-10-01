using ShoppingCard.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.ValueObjects
{
    public class CardItem
    {
        public EAN ean;
        public Quantity quantity;

        public CardItem(EAN ean, Quantity quantity)
        {
            this.ean = ean;
            this.quantity = quantity;
        }
    }
}
