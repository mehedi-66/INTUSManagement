using Microsoft.AspNetCore.Components;
using INTUSManagement.Model;
using System.Net.Http.Json;
namespace INTUSBlazorWebAssemblyApp.Pages
{
    public class ElementBase : ComponentBase
    {
        [Inject]
        public HttpClient httpClient { get; set; }
      

        public List<INTUSManagement.Model.Element> Elements { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(async () => await Load());
        }

        private async Task Load()
        {
            Elements = await httpClient.GetFromJsonAsync<List<INTUSManagement.Model.Element>>("/api/Elements");
        }

    }
}

