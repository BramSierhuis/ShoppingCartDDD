﻿using ShoppingCard.Aggregates.Abstract;
using ShoppingCard.Aggregates.Services;
using ShoppingCard.Core.Shared;
using ShoppingCard.Core.ValueObjects;
using ShoppingCard.Messages.Commands;
using ShoppingCard.Messages.Events;
using System.Collections.Generic;

namespace ShoppingCard.Aggregates.Aggregates
{
    public class ShoppingCardAggregate : AggregateRoot
    {
        public IList<CardItem> Items { get; private set; }
        public UserId UserId { get; private set; }

        private IDiscountService _discountService;

        private ShoppingCardAggregate() => Items = new List<CardItem>();

        public ShoppingCardAggregate(CreateShoppingCard command, IDiscountService discountService) : this()
        {
            Apply<ShoppingCardCreated>(e =>
            {
                e.UserId = command.UserId;
            });

            _discountService = discountService;
        }
            
        public void Handle(AddProductToCard command)
        {
            Apply<ProductAddedToCard>(e =>
            {
                e.Ean = command.Ean;
                e.Quantity = command.Quantity;
            });
        }

        protected override void Mutate(IEvent e)
            => When((dynamic)e);

        private void When(ProductAddedToCard @event)
        {
            Items.Add(new(@event.Ean, @event.Quantity));
        }

        private void When(ShoppingCardCreated @event)
        {
            UserId = @event.UserId;
        }
    }
}