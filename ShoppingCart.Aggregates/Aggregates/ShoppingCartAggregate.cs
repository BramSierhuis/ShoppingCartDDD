using ShoppingCart.Aggregates.Services;
using ShoppingCart.Core.Abstract;
using ShoppingCart.Core.Shared;
using ShoppingCart.Core.ValueObjects;
using ShoppingCart.Messages.Commands;
using ShoppingCart.Messages.Events;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Aggregates.Aggregates
{
    public class ShoppingCartAggregate : AggregateRoot<CartId>
    {
        public IList<CartItem> Items { get; private set; }
        public UserId UserId { get; private set; }

        private IDiscountService _discountService;

        private ShoppingCartAggregate() => Items = new List<CartItem>();

        public ShoppingCartAggregate(CreateShoppingCart command, IDiscountService discountService) : this()
        {
            Apply<ShoppingCartCreated>(e =>
            {
                e.CartId = command.CartId;
                e.UserId = command.UserId;
            });

            _discountService = discountService;
        }
            
        public void Handle(AddProductToCart command)
        {
            Apply<ProductAddedToCart>(e =>
            {
                e.ProductId = command.ProductId;
                e.CartId = command.CartId;
                e.Quantity = command.Quantity;
            });
        }

        protected override void Mutate(object e)
            => When((dynamic)e);

        private void When(ProductAddedToCart @event)
        {
            Items.Add(new(@event.ProductId, @event.Quantity));
        }

        private void When(ShoppingCartCreated @event)
        {
            Id = @event.CartId;
            UserId = @event.UserId;
        }
    }
}
