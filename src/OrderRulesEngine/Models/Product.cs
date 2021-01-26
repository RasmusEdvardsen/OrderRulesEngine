using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Models
{
    public class Product
    {
        public string Name { get; set; }
        public ProductType Type { get; set; }

        public Product()
        {
            Name = "";
            Type = ProductType.Standard;
        }

        public Product(string name, ProductType type)
        {
            Name = name;
            Type = type;
        }

        // NOTE: out of scope: ProductId, Price, etc.
    }
}
