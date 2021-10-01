using ShoppingCard.Aggregates;
using ShoppingCard.Messages.Commands;
using ShoppingCard.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCard.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_CreatesProduct()
        {
            // Given a name, ean, stock, discription
            string name = "TestProduct";
            string description = "Gewoon een mooi product ja?!";
            EAN ean = 1234567891234;
            Price price = (decimal)2.50;
            int stock = 4;

            CreateProduct command = new()
            {
                Name = name,
                Description = description,
                Ean = ean,
                Price = price,
                Stock = stock
            };

            // When a product is created
            var product = new ProductAggregate(command);

            // Then its values are set
            Assert.Equal(product.Name, name);
        }

        [Fact]
        public void ChangeName_ChangesName()
        {
            // Given a valid product with name set to TestProduct
            string name = "TestProduct";
            string description = "Gewoon een mooi product ja?!";
            EAN ean = 1234567891234;
            Price price = (decimal)2.50;
            int stock = 4;

            CreateProduct command = new() { 
                Name = name, 
                Description = description, 
                Ean = ean, 
                Price = price, 
                Stock = stock 
            };

            var product = new ProductAggregate(command);

            // When the name is changed to USB Charger
            string newName = "USB Charger";
            product.Handle(new ChangeProductName { Name = newName});

            // Then the name should be USB Charger and the version should be 1
            Assert.Equal(newName, product.Name);
            Assert.Equal(2, product.Version);
        }
    }
}
