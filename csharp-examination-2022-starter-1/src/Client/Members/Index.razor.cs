using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Members;
using System.Linq;
using System;

namespace Client.Members
{
    public partial class Index
    {
        [Inject] public IMemberService MemberService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        private List<MemberDto.Index> allMembers;
        private List<MemberDto.Index> filteredMembers;

        protected override async Task OnInitializedAsync()
        {
            await GetMembersAsync();
        }

        private async Task GetMembersAsync()
        {
            var response = await MemberService.GetIndexAsync(null);
            allMembers = response.Members;
            filteredMembers = allMembers;
        }

        private void NavigateToDetail(int memberId)
        {
            NavigationManager.NavigateTo($"member/{memberId}");
        }

        private void SearchMembers(ChangeEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
