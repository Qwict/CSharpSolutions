using Domain.Members;
using Shouldly;
using System;
using Xunit;

namespace UnitTests.Members
{
    public class Member_Should
    {
        [Fact]
        public void Have_one_subscription_after_adding_subscription()
        {
            var member = new MemberFaker().Generate();

            member.AddSubscription(new DateTime(2022, 08, 01));

            member.Subscriptions.Count.ShouldBe(1);
        }

        [Fact]
        public void Not_add_subscription_when_overlapping_with_another()
        {
            var member = new MemberFaker().Generate();
            member.AddSubscription(new DateTime(2022, 08, 01));

            Should.Throw<ApplicationException>(() => member.AddSubscription(new DateTime(2022, 08, 05)));
        }

    }
}
