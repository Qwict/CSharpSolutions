using System;
using FluentValidation;

namespace Shared.Members
{
    public static class MemberRequest
    {
        public class GetIndex
        {
        }

        public class Create
        {
            public string? Firstname { get; set; }
            public string? Lastname { get; set; }
            public DateTime DateOfBirth { get; set; }
            public GenderType Gender { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }

            // TODO: Vraag 6 Create
            public class Validator: AbstractValidator<Create>
            {
                public Validator()
                {
                    RuleFor(x => x.Firstname).NotEmpty();
                    RuleFor(x => x.Lastname).NotEmpty();
                    RuleFor(x => x.DateOfBirth).NotEmpty();
                    RuleFor(x => x.Gender).NotEmpty();
                    // I think this is optional??? but I don't understand this exam... it will throw if not done: protect API?
                    RuleFor(x => x.Email).NotEmpty().Matches("^(\\S+)@(\\S+)$").WithMessage("Email Address is not valid.").MaximumLength(200);
                    RuleFor(x => x.Phone).NotEmpty().MaximumLength(100);
                    
                }
            }
        }
    }
}
