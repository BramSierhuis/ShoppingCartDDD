using ShoppingCart.Core.Shared;

namespace ShoppingCart.Core.ValueObjects
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Price{ get; set; }
        public int Stock { get; set; }
        public EAN Ean { get; set; }
    }
}
