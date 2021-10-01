using ShoppingCard.Aggregates.Aggregates;
using ShoppingCard.Core.Shared;
using ShoppingCard.Messages.Commands;
using ShoppingCard.Messages.Events;
using ShoppingCard.Services;
using System;
using Xunit;

namespace ShoppingCard.Tests
{
    public class ShoppingCardTests
    {
        private ShoppingCardAggregate _shoppingCard;

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
            _shoppingCard = new ShoppingCardAggregate(command, fakeDiscountService);
            _shoppingCard.Hydrate(new[] { new ProductAddedToCard() { Ean = ean, Quantity = quantity } });
        }

        [Fact]
        public void D_AddProductToCard()
        {
            // Given a discount service, userId, Ean and Quantity
            FakeDiscountService fakeDiscountService = new();
            UserId userId = new(Guid.NewGuid());
            long ean = 1234567891234;
            int quantity = 4;

            CreateShoppingCard createCmd = new() { UserId = userId };

            // Then a card can be created and hydrated
            _shoppingCard = new ShoppingCardAggregate(createCmd, fakeDiscountService);

            AddProductToCard addCmd = new() { Ean = ean, Quantity = quantity };

            _shoppingCard.Handle(addCmd);

            Assert.Equal(1, _shoppingCard.Items.Count);
        }
    }
}
