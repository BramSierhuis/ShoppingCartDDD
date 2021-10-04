using System;

namespace ShoppingCart.Messages.Commands
{
    public class ChangeProductName : ICommand
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
