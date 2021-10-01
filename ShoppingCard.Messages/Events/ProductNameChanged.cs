namespace ShoppingCard.Messages.Events
{
    public class ProductNameChanged : IEvent
    {
        public string Name { get; set; }
    }
}
