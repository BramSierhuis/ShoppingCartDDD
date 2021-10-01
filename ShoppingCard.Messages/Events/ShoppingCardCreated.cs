using System;

namespace ShoppingCard.Messages.Events
{
    public class ShoppingCardCreated : IEvent
    {
        public Guid UserId { get; set; }
    }
}
