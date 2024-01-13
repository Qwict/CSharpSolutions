namespace Shared.Members
{
    public static class MemberRequest
    {
        public class GetIndex
        {
            // TODO: Antwoord 5: Filter
            public string Search { get; set; }
        }

        public class Create
        {
            public MemberDto.Mutate Member { get; set; }
        }
    }
}
