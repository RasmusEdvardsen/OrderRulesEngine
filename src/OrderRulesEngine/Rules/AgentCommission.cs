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
        public bool ShouldProcess(Order order) => order.Product is PhysicalProduct p;

        // NOTE: We could combine the 2 packing slip rules here.
        public bool Process(Order order)
        {
            if (order.Product is PhysicalProduct p && p.Type == PhysicalProductType.Book)
                return false;

            order.Payments.Add(new Payment(PaymentType.Commission, "Book agent"));

            return true;
        }
    }
}
