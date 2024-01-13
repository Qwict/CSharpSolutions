using Domain.Common;

namespace Domain.Members
{
    public class MemberFaker : EntityFaker<Member>
    {
        public MemberFaker(bool hasRandomId = true) : base(hasRandomId)
        {
            CustomInstantiator(f => new Member(new MemberName(f.Person.FirstName, f.Person.LastName), f.Person.DateOfBirth, (GenderType)f.Person.Gender, new EmailAddress(f.Person.Email), new Phonenumber(f.Person.Phone)));
        }
    }
}

