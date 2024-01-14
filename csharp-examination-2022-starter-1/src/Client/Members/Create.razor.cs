using Microsoft.AspNetCore.Components;
using Shared.Members;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace Client.Members
{
    public partial class Create
    {
        private MemberRequest.Create model { get; set; } = new();
        
        // TODO: Vraag 6 Create
        [Inject] public IMemberService Service { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        // TODO: Vraag 7: localstorage (inject)
        [Inject] public ILocalStorageService LocalStorage { get; set; }
        [Inject] public ISyncLocalStorageService LocalSyncStorage { get; set; }

        private async Task CreateMemberAsync()
        {
            await Service.CreateAsync(model);
            
            // TODO: Vraag 7: localstorage (add to storage after create)
            // await LocalStorage.RemoveItemAsync("members");
            LocalSyncStorage.RemoveItem("members");
            
            NavigationManager.NavigateTo("/");
        }
    }
}
