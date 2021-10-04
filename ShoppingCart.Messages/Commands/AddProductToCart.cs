using System;

namespace ShoppingCart.Messages.Commands
{
    public class AddProductToCart
    {
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
    }
}
