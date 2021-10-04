using EventStore.Client;
using Grpc.Net.Client;
using ShoppingCart.Core.AggregateStore;
using ShoppingCart.Core.Shared;
using ShoppingCart.Messages.Commands;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var settings = EventStoreClientSettings.Create("esdb://localhost:2113?tls=false");
            var client = new EventStoreClient(settings);

            AggregateStore store = new(client);
            ProductApplicationService service = new(store);

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
            ChangeProductName changeCmd = new() { ProductId = Guid.Parse("6ddc2db3-ff05-42d1-b9fd-2e05aeef638e"), Name = "new Name" };

            //service.Handle(command);
            service.Handle(changeCmd);

            Console.ReadLine();
        }
    }
}
