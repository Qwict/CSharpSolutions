using System;
using Domain.Members;
using Shouldly;
using Xunit;

namespace UnitTests.Members
{
    public class EmailAddress_Should
    {

        [Theory]
        [InlineData("")]
        [InlineData("member1#a.be")]
        [InlineData("member1.")]
        [InlineData("@domain")]
        [InlineData("@domain.be")]
        public void Not_be_created_when_invalid_format(string test)
        {
            Should.Throw<ArgumentException>(() => new EmailAddress(test));
        }

        [Theory]
        [InlineData("member1@gmail.com")]
        [InlineData("member1@hotmail.com")]
        [InlineData("member1@domain.training")]
        public void Be_created_when_valid_format(string test)
        {
            EmailAddress email = new(test);
            email.Value.ShouldBe(test);
        }
    }
}

