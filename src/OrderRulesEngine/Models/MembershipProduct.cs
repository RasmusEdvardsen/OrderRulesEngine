using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Models
{
    public class MembershipProduct : Product
    {
        public MembershipProductType Type { get; set; }

        public MembershipProduct(MembershipProductType type) { Type = type; }
    }
}
