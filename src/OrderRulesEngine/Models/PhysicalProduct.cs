using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Models
{
    public class PhysicalProduct : Product
    {
        public PhysicalProductType Type { get; set; }

        public PhysicalProduct(PhysicalProductType type) { Type = type; }
    }
}
