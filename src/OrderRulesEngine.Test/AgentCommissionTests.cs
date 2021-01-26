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
    public class AgentCommissionTests
    {
        [Fact]
        public void AgentCommission()
        {
            // arrange
            Order order = new(new PhysicalProduct(PhysicalProductType.Football), new(""));
            AgentCommission rule = new();

            // act
            var shouldProcess = rule.ShouldProcess(order);
            var processSucceeded = rule.Process(order);

            // assert
            Assert.True(shouldProcess);
            Assert.True(processSucceeded);
            Assert.Single(order.Payments);
            Assert.Equal(PaymentType.Commission, order.Payments[0].Type);
        }
    }
}
