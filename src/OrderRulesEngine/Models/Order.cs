using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Models
{
    public class Order
    {
        public List<Product> Products { get; set; }
        public List<PackingSlip> PackingSlips { get; set; }
        public Customer Customer { get; set; }
        public List<Payment> Payments { get; set; }

        public Order(Product product, Customer customer)
        {
            Products = new() { product };
            PackingSlips = new();
            Customer = customer;
            Payments = new();
        }

        // NOTE: Outside of scope: Billing, etc.
    }
}
