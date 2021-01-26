using Moq;
using OrderRulesEngine.DataAccess.Membership;
using OrderRulesEngine.Models;
using OrderRulesEngine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderRulesEngine.Test
{
    public class MembershipTests
    {
        private readonly Mock<IMembershipRepository> _moqMembershipRepository = new();

        [Fact]
        public void MembershipNew()
        {
            // arrange
            Order order = new(new MembershipProduct(MembershipProductType.New), new(""));
            MembershipNew rule = new(_moqMembershipRepository.Object);

            // act
            var shouldProcess = rule.ShouldProcess(order);
            var processSucceeded = rule.Process(order);

            // assert
            Assert.True(shouldProcess);
            Assert.True(processSucceeded);
            _moqMembershipRepository.Verify(x => x.ActivateMembership(It.IsAny<MembershipProduct>()), Times.Once);
        }

        [Fact]
        public void MembershipNewNoProcess()
        {
            // arrange
            Order order = new(new MembershipProduct(MembershipProductType.Upgrade), new(""));
            MembershipNew rule = new(_moqMembershipRepository.Object);

            // act
            var shouldProcess = rule.ShouldProcess(order);

            // assert
            Assert.False(shouldProcess);
        }

        [Fact]
        public void MembershipUpgrade()
        {
            // arrange
            Order order = new(new MembershipProduct(MembershipProductType.Upgrade), new(""));
            MembershipUpgrade rule = new(_moqMembershipRepository.Object);

            // act
            var shouldProcess = rule.ShouldProcess(order);
            var processSucceeded = rule.Process(order);

            // assert
            Assert.True(shouldProcess);
            Assert.True(processSucceeded);
            _moqMembershipRepository.Verify(x => x.UpgradeMembership(It.IsAny<MembershipProduct>()), Times.Once);
        }

        [Fact]
        public void MembershipUpgradeNoProcess()
        {
            // arrange
            Order order = new(new MembershipProduct(MembershipProductType.New), new(""));
            MembershipUpgrade rule = new(_moqMembershipRepository.Object);

            // act
            var shouldProcess = rule.ShouldProcess(order);

            // assert
            Assert.False(shouldProcess);
        }

        [Fact]
        public void MembershipAll()
        {
            // arrange
            Order order = new(new MembershipProduct(MembershipProductType.New), new(""));
            List<IOrderRule> rules = new() {
                new MembershipEmail(_moqMembershipRepository.Object),
                new MembershipNew(_moqMembershipRepository.Object),
                new MembershipUpgrade(_moqMembershipRepository.Object)
            };

            // act
            foreach (var rule in rules.Where(r => r.ShouldProcess(order)))
                rule.Process(order);

            // assert
            _moqMembershipRepository.Verify(x => x.ActivateMembership(It.IsAny<MembershipProduct>()), Times.Once);
            _moqMembershipRepository.Verify(x => x.ActivateMembership(It.IsAny<MembershipProduct>()), Times.Once);
            _moqMembershipRepository.Verify(x => x.ActivateMembership(It.IsAny<MembershipProduct>()), Times.Once);
        }
    }
}
