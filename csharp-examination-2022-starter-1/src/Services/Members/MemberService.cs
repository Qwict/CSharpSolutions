using System.Linq;
using System.Threading.Tasks;
using Shared.Members;
using Domain.Members;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Services.Members
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext dbContext;

        public MemberService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MemberResponse.GetIndex> GetIndexAsync(MemberRequest.GetIndex request)
        {
            MemberResponse.GetIndex response = new();

            response.Members = await dbContext.Members.Select(x => new MemberDto.Index
            {
                Id = x.Id,
                Name = x.Name.ToString(),
                Email = x.Email.Value,
                Phone = x.Phone.Value
            }).AsNoTracking()
            .ToListAsync();

            return response;
        }

        public async Task<MemberResponse.Create> CreateAsync(MemberRequest.Create request)
        {
            var memberName = new MemberName(request.Firstname!, request.Lastname!);
            var email = new EmailAddress(request.Email!);
            var phone = new Phonenumber(request.Phone!);

            var member = new Member(memberName, request.DateOfBirth, (Domain.Members.GenderType)request.Gender, email, phone);
            dbContext.Members.Add(member);
            await dbContext.SaveChangesAsync();
            return new MemberResponse.Create { MemberId = member.Id };
        }
    }
}
