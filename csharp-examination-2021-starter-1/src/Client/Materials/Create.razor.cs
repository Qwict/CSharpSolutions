using System;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Shared.Materials;

namespace Client.Materials
{
	public partial class Create
    {
        // TODO vraag 6: create
        private MaterialDto.Create _material = new();
        [Inject] public IMaterialService MaterialService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        // TODO vraag 8: notification
        [Inject] public  IToastService ToastService { get; set; }
        
        // TODO vraag 6: create
        private async Task SubmitForm()
        {
            var response = await MaterialService.CreateAsync(_material);
            // TODO vraag 8: notification
            if (response > 0)
            {
                ToastService.ShowSuccess("Materiaal is toegevoegd!");
                NavigationManager.NavigateTo("/");
            }

        }
    }
}

