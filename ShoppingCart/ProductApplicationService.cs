using ShoppingCart.Aggregates.Aggregates;
using ShoppingCart.Core.AggregateStore;
using ShoppingCart.Core.Shared;
using ShoppingCart.Messages.Commands;
using System;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class ProductApplicationService //TODO Implement : IApplicationService
    {
        private readonly IAggregateStore _store;

        public ProductApplicationService(IAggregateStore aggregateStore) => _store = aggregateStore;

        public void Handle(object command) => Handle((dynamic)command);

        private async Task Handle(CreateProduct cmd)
        {
            if (await _store.Exists<ProductAggregate, ProductId>(cmd.ProductId))
                throw new InvalidOperationException($"Product with id {cmd.ProductId} already exists");

            var product = new ProductAggregate(cmd);

            await _store.Save<ProductAggregate, ProductId>(product);
        }

        private async Task Handle(ChangeProductName cmd)
        {
            if (!await _store.Exists<ProductAggregate, ProductId>(cmd.ProductId))
                throw new InvalidOperationException($"Product with id {cmd.ProductId} does not exist");

            var product = await _store.Load<ProductAggregate, ProductId>(cmd.ProductId);

            product.Handle(cmd);

            await _store.Save<ProductAggregate, ProductId>(product);
        }
    }
}
