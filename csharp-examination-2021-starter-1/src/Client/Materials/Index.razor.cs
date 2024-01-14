using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Shared.Materials;
using Console = System.Console;

namespace Client.Materials
{
	public partial class Index
	{
        // TODO: Vraag 5 Filter
        private IEnumerable<MaterialDto.Index> materials;
        private string _searchTerm = "";
        [Parameter, SupplyParameterFromQuery] public string? Searchterm { get; set; }
        [Inject] public IMaterialService MaterialService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; } = default!;
        
        // TODO: Vraag 5 Filter
        // protected override async Task OnParametersSetAsync()
        // {
        //     await GetMaterialsAsync();
        // }
        
        // TODO: Vraag 5 Filter zonder param in header
        protected override Task OnInitializedAsync()
        {
            return GetMaterialsAsync();
        }
        
        private async Task GetMaterialsAsync()
        {
            materials = await MaterialService.GetIndexAsync(_searchTerm);
        }

        // TODO: Vraag 5 Filter met search param in header
        // private void FilterMaterials()
        // {
        //     Dictionary<string, object?> parameters = new();
        //     parameters.Add(nameof(Searchterm), _search);
        //     Console.WriteLine(_search);
        //     var uri = NavigationManager.GetUriWithQueryParameters(parameters);
        //     NavigationManager.NavigateTo(uri);
        // }
    }
}

