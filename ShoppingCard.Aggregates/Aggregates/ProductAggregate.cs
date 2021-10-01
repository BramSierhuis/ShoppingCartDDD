﻿using ShoppingCard.Aggregates.Abstract;
using ShoppingCard.Core.Shared;
using ShoppingCard.Messages.Commands;
using ShoppingCard.Messages.Events;

namespace ShoppingCard.Aggregates.Aggregates
{
    public class ProductAggregate : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Price Price { get; private set; }
        public int Stock { get; private set; }
        public EAN Ean { get; private set; }

        public ProductAggregate(CreateProduct command)
        {
            Apply<ProductCreated>(e =>
            {
                e.Name = command.Name;
                e.Description = command.Description;
                e.Price = command.Price;
                e.Stock = command.Stock;
                e.Ean = command.Ean;
            });
        }

        public void Handle(ChangeProductName command)
        {
            Apply<ProductNameChanged>(e =>
            {
                e.Name = command.Name;
            });
        }

        protected override void Mutate(IEvent e)
            => When((dynamic)e);

        private void When(ProductCreated @event)
        {
            Name = @event.Name;
            Description = @event.Description;
            Price = @event.Price;
            Stock = @event.Stock;
            Ean = @event.Ean;
        }

        private void When(ProductNameChanged @event)
        {
            Name = @event.Name;
        }
    }
}