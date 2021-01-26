using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Models
{
    public class Order
    {
        public Product Product { get; set; }
        public List<PackingSlip> PackingSlips { get; set; }

        public Order(Product product)
        {
            Product = product;
            PackingSlips = new();
        }

        // NOTE: Outside of scope: Billing, Customer, etc.
    }
}
