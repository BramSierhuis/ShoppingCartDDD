using ShoppingCart.Aggregates.Aggregates;
using ShoppingCart.Core.Shared;
using ShoppingCart.Messages.Commands;
using ShoppingCart.Messages.Events;
using ShoppingCart.Services;
using System;
using Xunit;

namespace ShoppingCart.Tests
{
    public class ShoppingCartTests
    {
        private ShoppingCartAggregate _shoppingCart;

        [Fact]
        public void CreateCart_CreatesCart()
        {
            // Given a discount service, userId, Ean and Quantity
            FakeDiscountService fakeDiscountService = new();
            UserId userId = new(Guid.NewGuid());
            CartId CartId = new(Guid.NewGuid());
            ProductId productId = new(Guid.NewGuid());
            Quantity quantity = 4;

            CreateShoppingCart command = new() { UserId = userId };

            // Then a Cart can be created and hydrated
            _shoppingCart = new ShoppingCartAggregate(command, fakeDiscountService);
            _shoppingCart.Hydrate(new[] { new ProductAddedToCart() { ProductId = productId, CartId = CartId, Quantity = quantity } });
        }

        [Fact]
        public void D_AddProductToCart()
        {
            // Given a discount service, userId, Ean and Quantity
            FakeDiscountService fakeDiscountService = new();
            UserId userId = new(Guid.NewGuid());
            CartId CartId = new(Guid.NewGuid());
            ProductId productId = new(Guid.NewGuid());
            Quantity quantity = 4;

            CreateShoppingCart createCmd = new() { UserId = userId };

            // Then a Cart can be created and hydrated
            _shoppingCart = new ShoppingCartAggregate(createCmd, fakeDiscountService);

            AddProductToCart addCmd = new() { ProductId = productId, CartId = CartId, Quantity = quantity };

            _shoppingCart.Handle(addCmd);

            Assert.Equal(1, _shoppingCart.Items.Count);
        }
    }
}
