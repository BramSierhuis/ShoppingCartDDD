using System;

namespace ShoppingCard.Messages.Commands
{
    public class AddProductToCard
    {
        public Guid ProductId { get; set; }
        public Guid CardId { get; set; }
        public int Quantity { get; set; }
    }
}
