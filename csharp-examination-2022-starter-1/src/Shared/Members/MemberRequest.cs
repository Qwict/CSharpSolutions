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

            public class Validator :AbstractValidator<Create>
            {
                public Validator()
                {
                    // Implement
                }
            }
        }
    }
}
