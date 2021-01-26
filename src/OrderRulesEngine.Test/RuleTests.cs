using OrderRulesEngine.Models;
using OrderRulesEngine.Rules;
using System;
using Xunit;

namespace OrderRulesEngine.Test
{
    public class RuleTests
    {
        [Fact]
        public void PackingSlipForShipping()
        {
            // arrange
            Order order = new(new(ProductType.Physical));
            ShippingPackingSlipPhysicalProduct rule = new();

            // act
            var shouldProcess = rule.ShouldProcess(order);
            var processSucceeded = rule.Process(order);

            // assert
            Assert.True(shouldProcess);
            Assert.True(processSucceeded);
        }

        [Fact]
        public void PackingSlipForShippingDoesntProcess()
        {
            // arrange
            Order order = new(new(ProductType.Book));
            ShippingPackingSlipPhysicalProduct rule = new();

            // act
            var shouldProcess = rule.ShouldProcess(order);

            // assert
            Assert.False(shouldProcess);
        }
    }
}
