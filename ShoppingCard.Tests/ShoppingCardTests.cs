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
            UserId userId = new(Guid.NewGuid());
            CardId cardId = new(Guid.NewGuid());
            ProductId productId = new(Guid.NewGuid());
            int quantity = 4;

            CreateShoppingCard command = new() { UserId = userId };

            // Then a card can be created and hydrated
            _shoppingCard = new ShoppingCardAggregate(command, fakeDiscountService);
            _shoppingCard.Hydrate(new[] { new ProductAddedToCard() { ProductId = productId, CardId = cardId, Quantity = quantity } });
        }

        [Fact]
        public void D_AddProductToCard()
        {
            // Given a discount service, userId, Ean and Quantity
            FakeDiscountService fakeDiscountService = new();
            UserId userId = new(Guid.NewGuid());
            CardId cardId = new(Guid.NewGuid());
            ProductId productId = new(Guid.NewGuid());
            int quantity = 4;

            CreateShoppingCard createCmd = new() { UserId = userId };

            // Then a card can be created and hydrated
            _shoppingCard = new ShoppingCardAggregate(createCmd, fakeDiscountService);

            AddProductToCard addCmd = new() { ProductId = productId, CardId = cardId, Quantity = quantity };

            _shoppingCard.Handle(addCmd);

            Assert.Equal(1, _shoppingCard.Items.Count);
        }
    }
}
