using ShoppingCard.Exceptions;
using ShoppingCard.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingCard.Tests
{
    public class BaseTests
    {
        [Fact]
        public void TwoMoneyRecordsShouldBeEqual()
        {
            // Given we have two equal amounts of money
            Money fromInt = Money.FromInt(10);
            Money fromString = Money.fromString("10");

            // When nothing

            // Then they should be equal
            Assert.Equal(fromInt, fromString);
        }

        [Fact]
        public void TwoQuantitiesShouldBeEqual()
        {
            // Given we have two equal amounts of money
            Quantity one = 4;
            Quantity two = 4;

            // When nothing

            // Then they should be equal
            Assert.Equal(one, two);
        }

        [Fact]
        public void ValidEanMustBeValid()
        {
            // Given we have a valid EAN
            long ean = 1234567891234;

            // When nothing

            // Then there should not be an error
            EAN test = ean;
            Assert.Equal(test, new EAN(ean));
        }

        [Fact]
        public void InvalidEanMustBeInvalid()
        {
            // Given we have a too long ean or to short ean
            long tooLong = 12345678912344;
            long tooShort = 12378912344;

            // When nothing

            // Then an error must be thrown
            Assert.Throws<ProductExceptions.InvalidEanException>(() => new EAN(tooLong));
            Assert.Throws<ProductExceptions.InvalidEanException>(() => new EAN(tooShort));
        }
    }
}
