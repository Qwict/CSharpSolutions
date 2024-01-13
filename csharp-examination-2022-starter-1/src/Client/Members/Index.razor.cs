using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Members;
using System.Linq;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Client.Members
{
    public partial class Index
    {
        [Inject] public IMemberService MemberService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public Blazored.LocalStorage.ISyncLocalStorageService LocalStorage { get; set; }

        private List<MemberDto.Index> allMembers;
        private List<MemberDto.Index> filteredMembers;
        protected override async Task OnInitializedAsync()
        {
            // TODO: Vraag 7: localstorage
            var members = LocalStorage.GetItemAsString("members");
            if (!string.IsNullOrEmpty(members))
            {
                try
                {
                    // allMembers = System.Text.Json.JsonSerializer.Deserialize<List<MemberDto.Index>>(members);
                    allMembers = await JsonSerializer.DeserializeAsync<List<MemberDto.Index>>(
                        new MemoryStream(Encoding.UTF8.GetBytes(members)),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );
                    filteredMembers = allMembers;
                    Console.WriteLine($"Deserialized Members: {string.Join(", ", allMembers.Select(m => m.Name))}");
                } catch (Exception e)
                {
                    Console.WriteLine($"Error deserializing members: {e.Message}");
                    await GetMembersAsync();
                    LocalStorage.SetItem("members", JsonSerializer.Serialize(allMembers));
                }
            }
            else
            {
                await GetMembersAsync();
                LocalStorage.SetItem("members", JsonSerializer.Serialize(allMembers));
            }
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
