using Shared.Members;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        // TODO: Vraag 5 Filter
        [HttpGet]
        public Task<MemberResponse.GetIndex> GetIndexAsync([FromQuery] MemberRequest.GetIndex request)
        {
            return _memberService.GetIndexAsync(request);
        }

        [HttpPost]
        public Task<MemberResponse.Create> CreateAsync([FromBody] MemberRequest.Create request)
        {
            return _memberService.CreateAsync(request);
        }
    }
}
