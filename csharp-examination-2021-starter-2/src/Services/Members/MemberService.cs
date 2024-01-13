using System;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.Members;
using Domain.Members;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Members
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _dbContext;

        public MemberService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MemberResponse.GetIndex> GetIndexAsync(MemberRequest.GetIndex request)
        {
            MemberResponse.GetIndex response = new();
            // TODO: Antwoord 5: Filter
            if (request.Search != null)
            {
                response.Members = await _dbContext.Members
                    .Where(x => x.Name.FirstName.Contains(request.Search) || x.Name.LastName.Contains(request.Search))
                    .Select(x => new MemberDto.Index
                    {
                        Id = x.Id,
                        FirstName = x.Name.FirstName,
                        LastName = x.Name.LastName,
                        Email = x.Email,
                        TwitterHandle = x.TwitterHandle,
                    }).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToListAsync();

                return response;
            }
            
            // TODO: Antwoord 5: Filter (indien leeg)
            response.Members = await _dbContext.Members.Select(x => new MemberDto.Index
            {
                Id = x.Id,
                FirstName = x.Name.FirstName,
                LastName = x.Name.LastName,
                Email = x.Email,
                TwitterHandle = x.TwitterHandle,
            }).ToListAsync();

            return response;
        }

        public async Task<MemberResponse.Create> CreateAsync(MemberRequest.Create request)
        {
            MemberResponse.Create response = new();
            var model = request.Member;

            var group = await _dbContext.Groups.SingleOrDefaultAsync(g => g.Id == model.GroupId);

            var member = new Member(
                new MemberName(model.FirstName, model.LastName),
                model.Email,
                model.TwitterHandle,
                group
            );

            _dbContext.Members.Add(member);
            await _dbContext.SaveChangesAsync();

            response.MemberId = member.Id;

            return response;
        }
    }
}
