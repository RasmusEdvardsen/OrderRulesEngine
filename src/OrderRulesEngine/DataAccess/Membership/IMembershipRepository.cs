using OrderRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.DataAccess.Membership
{
    public interface IMembershipRepository
    {
        void ActivateMembership(MembershipProduct product);
        void UpgradeMembership(MembershipProduct product);
        void EmailCustomer(Customer customer);
    }
}
