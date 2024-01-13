using System;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Shared.Groups;
using Shared.Members;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Members
{
    public partial class Create
    {
        [Inject] public IGroupService GroupService { get; set; }
        [Inject] public IMemberService MemberService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IToastService ToastService { get; set; }
        
        private List<GroupDto.Index> groups = new();
        
        private MemberDto.Mutate _member = new();

        private string LastName = "";
        protected override async Task OnInitializedAsync()
        {
            await GetGroupsAsync();
        }

        private async void CreateMemberAsync()
        {
            MemberRequest.Create request = new()
            {
                Member = _member
            };
            
            Console.WriteLine("Member" + request.Member.FirstName);
            Console.WriteLine("Member" + LastName);
            var response = await MemberService.CreateAsync(request);
            if (response.MemberId > 0)
            {
                NavigationManager.NavigateTo("/");
                ToastService.ShowSuccess(request.Member.FirstName + " " + request.Member.LastName + " was added!", "Success");
            }
        }

        private async Task GetGroupsAsync()
        {
            GroupRequest.GetIndex request = new();
            var response = await GroupService.GetIndexAsync(request);
            groups = response.Groups;
        }
    }
}
