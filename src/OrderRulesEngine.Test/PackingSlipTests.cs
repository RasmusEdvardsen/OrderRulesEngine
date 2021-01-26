using OrderRulesEngine.Models;
using OrderRulesEngine.Rules;
using System;
using System.Linq;
using Xunit;

namespace OrderRulesEngine.Test
{
    public class PackingSlipTests
    {
        [Fact]
        public void PackingSlipForShipping()
        {
            // arrange
            Order order = new(new PhysicalProduct(PhysicalProductType.Football), new(""));
            PackingSlipShipping rule = new();

            // act
            var shouldProcess = rule.ShouldProcess(order);
            var processSucceeded = rule.Process(order);

            // assert
            Assert.True(shouldProcess);
            Assert.True(processSucceeded);
            Assert.Single(order.PackingSlips);
            Assert.Equal("Shipping", order.PackingSlips[0].Recipient);
        }

        [Fact]
        public void PackingSlipForShippingDoesntProcess()
        {
            // arrange
            Order order = new(new(), new(""));
            PackingSlipShipping rule = new();

            // act
            var shouldProcess = rule.ShouldProcess(order);

            // assert
            Assert.False(shouldProcess);
        }

        [Fact]
        public void PackingSlipRoyalties()
        {
            // arrange
            Order order = new(new PhysicalProduct(PhysicalProductType.Book), new(""));
            PackingSlipRoyalties rule = new();

            // act
            var shouldProcess = rule.ShouldProcess(order);
            var processSucceeded = rule.Process(order);

            // assert
            Assert.True(shouldProcess);
            Assert.True(processSucceeded);
            Assert.Single(order.PackingSlips);
            Assert.Equal("Royalties", order.PackingSlips[0].Recipient);
        }

        [Fact]
        public void PackingSlipRoyaltiesNotABook()
        {
            // arrange
            Order order = new(new(), new(""));
            PackingSlipShipping rule = new();

            // act
            var shouldProcess = rule.ShouldProcess(order);

            // assert
            Assert.False(shouldProcess);
        }

        [Fact]
        public void PackingSlipMultipleIdenticalIds()
        {
            // arrange
            Order order = new(new PhysicalProduct(PhysicalProductType.Book), new(""));
            PackingSlipRoyalties rule1 = new();
            PackingSlipShipping rule2 = new();

            // act
            var shouldProcess1 = rule1.ShouldProcess(order);
            var processSucceeded1 = rule1.Process(order);
            
            var shouldProcess2 = rule2.ShouldProcess(order);
            var processSucceeded2 = rule2.Process(order);

            // assert
            Assert.True(shouldProcess1);
            Assert.True(shouldProcess2);
            Assert.True(processSucceeded1);
            Assert.True(processSucceeded2);

            Assert.Equal(2, order.PackingSlips.Count);
            var groupedById = order.PackingSlips.GroupBy(slips => slips.Id);
            Assert.Equal(1, groupedById.Count()); // Expecting 1 group, else ids differ
        }
    }
}
