using System;

namespace ShoppingCart.Messages.Events
{
    public class ProductAddedToCart : IEvent
    {
        public Guid ProductId { get; set; }
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
    }
}
