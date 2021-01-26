using OrderRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Rules
{
    /// <summary>
    /// Will create a packing slip for physical products.
    /// Implicitly (from problem statement) should check if packing slip for royalty department already exists.
    /// If yes, then duplicate this. For this purpose "duplicating" means same Id
    /// </summary>
    public class PackingSlipShipping : IOrderRule
    {
        public bool ShouldProcess(Order order) => order.Product is PhysicalProduct;
        
        // NOTE: We could combine the 2 packing slip rules here.
        public bool Process(Order order)
        {
            var packingSlip = new PackingSlip("Shipping");
            if (order.PackingSlips.Any())
                packingSlip.Id = order.PackingSlips[0].Id;

            order.PackingSlips.Add(packingSlip);

            return true;
        }
    }
}
