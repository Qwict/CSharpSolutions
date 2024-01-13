using System;
using Domain.Members;
using Shouldly;
using Xunit;

namespace UnitTests.Members
{
    public class Phonenumber_Should
    {
        [Fact]
        public void Be_stripped_of_spaces()
        {
            // TODO: vraag 2a unit test schrijven
            var phoneNumber = new Phonenumber("0476 123 456");
            phoneNumber.Value.ShouldBe("0476123456");
        }
    }
}

