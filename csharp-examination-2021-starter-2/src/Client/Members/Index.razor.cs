using System;
using Microsoft.AspNetCore.Components;
using Shared.Members;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Members
{
    public partial class Index
    {
        // TODO: Vraag 5 Filter
        [Inject] public NavigationManager NavigationManager { get; set; } = default!;
        [Parameter, SupplyParameterFromQuery] public string Search { get; set; }
        
        private string _search;
        [Inject] public IMemberService MemberService { get; set; }

        private List<MemberDto.Index> members;

        // TODO: Vraag 5 Filter
        protected override async Task OnParametersSetAsync()
        {
            await GetMembersAsync();
        }

        private async Task GetMembersAsync()
        {
            // TODO: Vraag 5 Filter
            MemberRequest.GetIndex request = new() { Search = _search };
            var response = await MemberService.GetIndexAsync(request);
            members = response.Members;
        }
        
        // TODO: Vraag 5 Filter
        private void SearchMembersAsync()
        {
            Dictionary<string, object?> parameters = new();
            
            if (!string.IsNullOrWhiteSpace(_search))
            {
                parameters.Add(nameof(Search), _search);
            }
            
            var uri = NavigationManager.GetUriWithQueryParameters(parameters);
            NavigationManager.NavigateTo(uri);
        }
    }
}
