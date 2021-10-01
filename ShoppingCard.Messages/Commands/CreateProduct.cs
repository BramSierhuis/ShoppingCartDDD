namespace ShoppingCard.Messages.Commands
{
    public class CreateProduct : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public long Ean { get; set; }
    }
}
