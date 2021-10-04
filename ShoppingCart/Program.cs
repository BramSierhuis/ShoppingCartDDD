using EventStore.Client;
using ShoppingCart.Core.AggregateStore;
using ShoppingCart.Core.Shared;
using ShoppingCart.Messages.Commands;
using System;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            FakeDiscountService discountService = new FakeDiscountService();
            var settings = EventStoreClientSettings.Create("esdb://localhost:2113?tls=false");
            var client = new EventStoreClient(settings);

            AggregateStore store = new(client);
            ProductApplicationService productService = new(store);
            ShoppingCartApplicationService cartService = new(store, discountService);

            //ProductTest
            ProductId productId = Guid.NewGuid();
            string name = "TestProduct";
            string description = "Gewoon een mooi product ja?!";
            EAN ean = 1234567891234;
            Price price = (decimal)2.50;
            int stock = 4;

            CreateProduct command = new()
            {
                ProductId = productId,
                Name = name,
                Description = description,
                Ean = ean,
                Price = price,
                Stock = stock
            };
            ChangeProductName changeCmd = new() { ProductId = productId, Name = "new Name" };

            await productService.Handle(command);
            await productService.Handle(changeCmd);


            //CardTest
            CartId cartId = Guid.NewGuid();
            UserId userId = Guid.NewGuid();

            CreateShoppingCart createShoppingCart = new CreateShoppingCart { CartId = cartId, UserId = userId };

            await cartService.Handle(createShoppingCart);
        }
    }
}
