using ShoppingCard.Core.Shared;

namespace ShoppingCard.Core.ValueObjects
{
    public class CardItem
    {
        public ProductId ProductId {  get; set; }
        public Quantity quantity;

        public CardItem(ProductId productId, Quantity quantity)
        {
            this.ProductId = productId;
            this.quantity = quantity;
        }
    }
}
