using FluentValidation;

namespace Shared.Members
{
    public static class MemberDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string Email { get; set; } = default!;
            public string Phone { get; set; } = default!;
        }
    }
}
