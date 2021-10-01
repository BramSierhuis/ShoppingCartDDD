using System;

namespace ShoppingCard.Messages.Commands
{
    public class CreateShoppingCard : ICommand
    {
        public Guid UserId {  get; set; }
    }
}
