using System;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Shared.Materials;

namespace Client.Materials
{
	public partial class Create
	{
		[Inject] public NavigationManager NavigationManager { get; set; }
		[Inject] public IMaterialService Service { get; set; }
		[Inject] public IToastService ToastService { get; set; }
        private MaterialDto.Create _new = new();
        private async Task SubmitForm()
        {
	        var response = await Service.CreateAsync(_new);
	        if (response > 0)
	        {
		        NavigationManager.NavigateTo("/");
		        ToastService.ShowSuccess("Materiaal is toegevoegd", "Success");
	        }
        }
    }
}

