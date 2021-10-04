using System;

namespace ShoppingCart.Messages.Events
{
    public class ProductNameChanged : IEvent
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
