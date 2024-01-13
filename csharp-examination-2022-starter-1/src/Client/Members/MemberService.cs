using System.Net.Http;
using System.Threading.Tasks;
using Client.Extensions;
using System.Net.Http.Json;
using Shared.Members;
using Blazored.LocalStorage;

namespace Client.Members
{
    public class MemberService : IMemberService
    {
        private readonly HttpClient httpClient;
        private const string endpoint = "api/member";

        public MemberService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<MemberResponse.GetIndex> GetIndexAsync(MemberRequest.GetIndex request)
        {
            var response = await httpClient.GetFromJsonAsync<MemberResponse.GetIndex>(endpoint);
            return response;
        }

        public async Task<MemberResponse.Create> CreateAsync(MemberRequest.Create request)
        {
            var response = await httpClient.PostAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<MemberResponse.Create>();
        }
    }
}
