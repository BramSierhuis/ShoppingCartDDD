using ShoppingCart.Core.Shared;

namespace ShoppingCart.Core.ValueObjects
{
    public class CartItem
    {
        public ProductId ProductId {  get; set; }
        public Quantity quantity;

        public CartItem(ProductId productId, Quantity quantity)
        {
            this.ProductId = productId;
            this.quantity = quantity;
        }
    }
}
