using ShoppingCard.Aggregates;
using ShoppingCard.Messages.Commands;
using ShoppingCard.Messages.Events;
using ShoppingCard.Services;
using ShoppingCard.Shared;
using ShoppingCard.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCard.Tests
{
    public class ShoppingCardTests
    {
        [Fact]
        public void CreateCard_CreatesCard()
        {
            // Given a discount service, userId, Ean and Quantity
            FakeDiscountService fakeDiscountService = new();
            UserId userId = new (Guid.NewGuid());
            long ean = 1234567891234;
            int quantity = 4;

            CreateShoppingCard command = new() { UserId = userId };

            // Then a card can be created and hydrated
            var card = new ShoppingCardAggregate(command, fakeDiscountService);
            card.Hydrate(new[] { new ProductAddedToCard() { Ean = ean, Quantity = quantity } });
        }
    }
}
