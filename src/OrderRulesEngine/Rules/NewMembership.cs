using OrderRulesEngine.DataAccess.Membership;
using OrderRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Rules
{
    public class NewMembership : IOrderRule
    {
        private readonly IMembershipRepository _membershipRepository;

        public NewMembership(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public bool ShouldProcess(Order order) =>
            order.Product is MembershipProduct m && m.Type == MembershipProductType.New;

        public bool Process(Order order)
        {
            if (order.Product is not MembershipProduct membershipProduct)
                return false;

            _membershipRepository.ActivateMembership(membershipProduct);

            return true;
        }
    }
}
