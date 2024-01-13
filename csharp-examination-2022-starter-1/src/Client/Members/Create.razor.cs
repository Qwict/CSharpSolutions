using Microsoft.AspNetCore.Components;
using Shared.Members;
using System;
using System.Threading.Tasks;

namespace Client.Members
{
    public partial class Create
    {
        private MemberRequest.Create model { get; set; } = new();
        
        // TODO: Vraag 6 Create
        [Inject] public IMemberService Service { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        private async Task CreateMemberAsync()
        {
            await Service.CreateAsync(model);
            NavigationManager.NavigateTo("/");
        }
    }
}
