using OrderRulesEngine.DataAccess.Membership;
using OrderRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Rules
{
    public class MembershipEmail : IOrderRule
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipEmail(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public bool ShouldProcess(Order order) =>
            order.Product is MembershipProduct m;

        public bool Process(Order order)
        {
            if (order.Product is not MembershipProduct m)
                return false;

            _membershipRepository.EmailCustomer(order.Customer, m.Type);

            return true;
        }
    }
}
