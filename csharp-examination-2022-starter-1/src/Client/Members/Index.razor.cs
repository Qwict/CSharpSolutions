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

        
        // TODO: Vraag 5 local filter
        private string _searchTerm = ""; // Initialize searchTerm

        private void SearchMembers(ChangeEventArgs args)
        {
            _searchTerm = args.Value?.ToString(); // Update searchTerm with the current value of the input field

            if (string.IsNullOrEmpty(_searchTerm))
            {
                // Clear the filtered list if the search term is empty
                filteredMembers = allMembers.OrderBy(x => x.Name).ToList();
            }
            else
            {
                Console.WriteLine("Filtering for " + _searchTerm);
                filteredMembers = allMembers
                    .FindAll(x => x.Name.Contains(_searchTerm, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(x => x.Name).ToList();
            }
        }
    }
}
