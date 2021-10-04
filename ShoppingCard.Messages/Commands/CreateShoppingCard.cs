using System;

namespace ShoppingCard.Messages.Commands
{
    public class CreateShoppingCard : ICommand
    {
        public Guid CardId {  get; set; }
        public Guid UserId {  get; set; }
    }
}
