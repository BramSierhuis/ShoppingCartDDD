namespace ShoppingCard.Messages.Commands
{
    public class ChangeProductName : ICommand
    {
        public string Name { get; set; }
    }
}
