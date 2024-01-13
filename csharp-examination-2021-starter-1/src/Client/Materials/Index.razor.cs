using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Shared.Materials;

namespace Client.Materials
{
	public partial class Index
	{
        // TODO: Vraag 5 Filter
        [Inject] public NavigationManager NavigationManager { get; set; } = default!;
        [Parameter, SupplyParameterFromQuery] public string Search { get; set; }
        private string _search;
        
        private IEnumerable<MaterialDto.Index> materials;
        [Inject] public IMaterialService MaterialService { get; set; }
        
        // TODO: Vraag 5 Filter
        protected override async Task OnParametersSetAsync()
        {
            await GetMaterialsAsync();
        }
        // protected override Task OnInitializedAsync()
        // {
        //     return GetMaterialsAsync();
        // }

        private async Task GetMaterialsAsync()
        {
            materials = await MaterialService.GetIndexAsync(null);
            // TODO: Vraag 5 Filter
            materials = await MaterialService.GetIndexAsync(_search);
        }
        
        // TODO: Vraag 5 Filter
        private void SearchMaterialsAsync()
        {
            Dictionary<string, object?> parameters = new();
            parameters.Add(nameof(Search), _search);
            var uri = NavigationManager.GetUriWithQueryParameters(parameters);
            NavigationManager.NavigateTo(uri);
        }
    }
}

