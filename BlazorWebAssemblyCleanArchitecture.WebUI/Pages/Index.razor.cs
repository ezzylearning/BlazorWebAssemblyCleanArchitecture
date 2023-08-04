using BlazorWebAssemblyCleanArchitecture.Application.Features.Stadiums.Queries.GetAllStadiums;

using Microsoft.AspNetCore.Components;

using System.Net.Http.Json;

using static System.Net.Mime.MediaTypeNames;

namespace BlazorWebAssemblyCleanArchitecture.WebUI.Pages
{
    public partial class Index
    {
        [Inject]
        private HttpClient Http { get; set; }

        private List<GetAllStadiumsDto> stadiums;

        protected override async Task OnInitializedAsync()
        {
            stadiums = await Http.GetFromJsonAsync<List<GetAllStadiumsDto>>("api/stadiums");
        }
    }
}
