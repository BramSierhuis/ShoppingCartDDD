using ShoppingCard.Core.Shared;

namespace ShoppingCard.Core.ValueObjects
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
