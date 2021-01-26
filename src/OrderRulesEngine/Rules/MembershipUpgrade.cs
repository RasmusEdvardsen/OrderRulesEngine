using OrderRulesEngine.DataAccess.Membership;
using OrderRulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderRulesEngine.Rules
{
    public class MembershipUpgrade : IOrderRule
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipUpgrade(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public bool ShouldProcess(Order order) =>
            order.Products.Any(p => p is MembershipProduct m && m.Type is MembershipProductType.Upgrade);

        public bool Process(Order order)
        {
            var products = order.Products.Where(p => p is MembershipProduct m && m.Type == MembershipProductType.Upgrade);
            foreach (MembershipProduct product in products)
                _membershipRepository.UpgradeMembership(product);
            return true;
        }
    }
}
