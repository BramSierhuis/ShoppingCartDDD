using ShoppingCart.Aggregates.Aggregates;
using ShoppingCart.Aggregates.Services;
using ShoppingCart.Core;
using ShoppingCart.Core.AggregateStore;
using ShoppingCart.Core.Shared;
using ShoppingCart.Messages.Commands;
using System;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class ShoppingCartApplicationService : IApplicationService
    {
        private readonly IAggregateStore _store;
        private readonly IDiscountService _discountService;

        public ShoppingCartApplicationService(IAggregateStore aggregateStore, IDiscountService discountService)
        {
            _discountService = discountService;
            _store = aggregateStore;
        }

        public async Task Handle(object command) => await Handle((dynamic)command);

        private async Task Handle(CreateShoppingCart cmd)
        {
            if (await _store.Exists<ShoppingCartAggregate, CartId>(cmd.CartId))
                throw new InvalidOperationException($"Cart with id {cmd.CartId} already exists");

            var cart = new ShoppingCartAggregate(cmd, _discountService);

            await _store.Save<ShoppingCartAggregate, CartId>(cart);
        }

        private async Task Handle(AddProductToCart cmd)
        {
            if (!await _store.Exists<ShoppingCartAggregate, CartId>(cmd.CartId))
                throw new InvalidOperationException($"Cart with id {cmd.CartId} does not exist");

            if (!await _store.Exists<ProductAggregate, ProductId>(cmd.ProductId))
                throw new InvalidOperationException($"Product with id {cmd.ProductId} does not exist");

            var cart = await _store.Load<ShoppingCartAggregate, CartId>(cmd.CartId);

            cart.Handle(cmd);

            await _store.Save<ShoppingCartAggregate, CartId>(cart);
        }
    }
}