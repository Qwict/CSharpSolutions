using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shared.Members;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService memberService;

        public MemberController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        [HttpGet]
        public Task<MemberResponse.GetIndex> GetIndexAsync()
        {
            return memberService.GetIndexAsync(new MemberRequest.GetIndex());
        }

    }
}

