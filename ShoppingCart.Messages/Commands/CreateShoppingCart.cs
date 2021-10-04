using System;

namespace ShoppingCart.Messages.Commands
{
    public class CreateShoppingCart : ICommand
    {
        public Guid CartId {  get; set; }
        public Guid UserId {  get; set; }
    }
}
