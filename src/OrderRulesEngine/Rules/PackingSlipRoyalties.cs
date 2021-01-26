using OrderRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Rules
{
    public class PackingSlipRoyalties : IOrderRule
    {
        public bool ShouldProcess(Order order) =>
            order.Product is PhysicalProduct p && p.Type == PhysicalProductType.Book;

        // NOTE: We could combine the 2 packing slip rules here.
        public bool Process(Order order)
        {
            var packingSlip = new PackingSlip("Royalties");
            if (order.PackingSlips.Any())
                packingSlip.Id = order.PackingSlips[0].Id;

            order.PackingSlips.Add(packingSlip);
            
            return true;
        }
    }
}
