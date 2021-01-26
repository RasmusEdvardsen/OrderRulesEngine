using OrderRulesEngine.Models;
using OrderRulesEngine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderRulesEngine.Test
{
    public class VideoProductTests
    {
        [Fact]
        public void ComplimentaryVideoProduct()
        {
            // arrange
            Order order = new(new VideoProduct("Learning to Ski", ProductType.Standard), new(""));
            LearningToSki rule = new();

            // act
            var shouldProcess = rule.ShouldProcess(order);
            var processSucceeded = rule.Process(order);

            // assert
            Assert.True(shouldProcess);
            Assert.True(processSucceeded);
            Assert.Equal(2, order.Products.Count);
            Assert.Single(order.Products.Where(p => p.Type == ProductType.Complimentary));
        }
    }
}
