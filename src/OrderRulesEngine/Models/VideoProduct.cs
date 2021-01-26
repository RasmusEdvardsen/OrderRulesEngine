using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Models
{
    public class VideoProduct : Product
    {
        public VideoProduct(string name, ProductType type) : base(name, type) { }
    }
}
