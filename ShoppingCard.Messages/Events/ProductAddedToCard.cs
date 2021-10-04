using System;

namespace ShoppingCard.Messages.Events
{
    public class ProductAddedToCard : IEvent
    {
        public Guid ProductId { get; set; }
        public Guid CardId { get; set; }
        public int Quantity { get; set; }
    }
}
