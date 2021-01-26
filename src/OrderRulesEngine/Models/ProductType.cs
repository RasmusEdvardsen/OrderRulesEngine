using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Models
{
    public enum ProductType
    {
        Unspecified,
        Physical,
        Book, // NOTE: Should maybe be subtype, PhysicalProductType.Book
        Membership,
        MembershipUpgrade, // NOTE: As above, maybe MembershipProductType.Upgrade, or a prop (.IsUpgrade)
        Video
    }
}
