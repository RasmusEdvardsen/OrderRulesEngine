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
            order.Products.Any(p => p is MembershipProduct);

        public bool Process(Order order)
        {
            foreach (MembershipProduct product in order.Products.Where(p => p is MembershipProduct))
                _membershipRepository.EmailCustomer(order.Customer, product.Type);
            return true;
        }
    }
}
