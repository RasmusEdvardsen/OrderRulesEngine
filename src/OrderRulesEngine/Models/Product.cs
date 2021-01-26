using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Models
{
    public class Product
    {
        public ProductType Type { get; set; }

        public Product() { Type = new(); }

        public Product(ProductType type) { Type = type; }
    }
}
