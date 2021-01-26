using OrderRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Rules
{
    interface IOrderRule
    {
        // Check if rule is pertinent to order
        public bool ShouldProcess(Order order);

        // Process rule, return false if failure.
        public bool Process(Order order);
    }
}
