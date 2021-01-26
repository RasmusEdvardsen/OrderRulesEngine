using OrderRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.DataAccess.Membership
{
    public class MembershipRepository : IMembershipRepository
    {
        public void ActivateMembership(MembershipProduct product)
        {
            // implement logic
        }

        public void EmailCustomer(Customer customer, MembershipProductType type)
        {
            // implement logic
        }

        public void UpgradeMembership(MembershipProduct product)
        {
            // implement logic
        }
    }
}
