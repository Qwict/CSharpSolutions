using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Members;
using System.Linq;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;

namespace Client.Members
{
    public partial class Index
    {
        [Inject] public IMemberService MemberService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        // TODO: Vraag 7: localstorage
        // Best localstorage (only works in wasm)
        [Inject] public ILocalStorageService LocalStorage { get; set; }
        // Slower async localstorage
        [Inject] public ISyncLocalStorageService LocalSyncStorage { get; set; }

        private List<MemberDto.Index> allMembers;
        private List<MemberDto.Index> filteredMembers;
        protected override async Task OnInitializedAsync()
        {
            // TODO: Vraag 7: localstorage
            var members = LocalSyncStorage.GetItem<List<MemberDto.Index>>("members");
            // var members = await LocalStorage.GetItemAsync<List<MemberDto.Index>>("members");
            if (members == null)
            {
                await GetMembersAsync();
            }
            else
            {
                allMembers = members;
                filteredMembers = allMembers;
            }
        }

        private async Task GetMembersAsync()
        {
            var response = await MemberService.GetIndexAsync(null);
            var members = response.Members.OrderBy(x => x.Name).ToList();
            
            // TODO: Vraag 7: localstorage
            LocalSyncStorage.SetItem("members", members);
            // LocalStorage.SetItemAsync("members", members);
            
            allMembers = members;
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
