using OrderRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Rules
{
    public class AgentCommission : IOrderRule
    {
        public bool ShouldProcess(Order order) => order.Products.Any(p => p is PhysicalProduct);

        // NOTE: We could combine the 2 packing slip rules here.
        public bool Process(Order order)
        {
            order.Payments.Add(new Payment(PaymentType.Commission, "Book agent"));
            return true;
        }
    }
}
