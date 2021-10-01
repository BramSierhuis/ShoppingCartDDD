namespace ShoppingCard.Messages.Events
{
    public class ProductAddedToCard : IEvent
    {
        public long Ean { get; set; }
        public int Quantity { get; set; }
    }
}
