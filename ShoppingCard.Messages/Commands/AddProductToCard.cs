namespace ShoppingCard.Messages.Commands
{
    public class AddProductToCard
    {
        public long Ean { get; set; }
        public int Quantity { get; set; }
    }
}
