using OrderRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Rules
{
    public class LearningToSki : IOrderRule
    {
        private const string LEARNING_TO_SKI = "Learning to Ski";

        public bool Process(Order order) =>
            order.Products.Any(p => p.Name == LEARNING_TO_SKI);

        public bool ShouldProcess(Order order)
        {
            VideoProduct videoProduct = new("First Aid", ProductType.Complimentary);
            order.Products.Add(videoProduct);
            return true;
        }
    }
}
