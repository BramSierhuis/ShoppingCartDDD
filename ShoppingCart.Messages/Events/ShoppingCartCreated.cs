using System;

namespace ShoppingCard.Messages.Events
{
    public class ShoppingCardCreated : IEvent
    {
        public Guid CardId {  get; set; }
        public Guid UserId { get; set; }
    }
}
