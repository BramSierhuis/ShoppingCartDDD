using System;

namespace ShoppingCart.Messages.Events
{
    public class ShoppingCartCreated : IEvent
    {
        public Guid CartId {  get; set; }
        public Guid UserId { get; set; }
    }
}
