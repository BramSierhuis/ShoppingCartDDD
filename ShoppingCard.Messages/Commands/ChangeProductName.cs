using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCard.Messages.Commands
{
    public class ChangeProductName : ICommand
    {
        public string Name { get; set; }
    }
}
