using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Messages.Commands
{
    public class CreateShoppingCard : ICommand
    {
        public Guid UserId {  get; set; }
    }
}
