using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace INTUSBlazorWebAssemblyApp.Pages
{
    public class OrdersallBase: ComponentBase
    {
        [Inject]
        public HttpClient httpClient { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<INTUSManagement.Model.Order> Orders { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(async () => await Load());
        }

        private async Task Load()
        {
            Orders = await httpClient.GetFromJsonAsync<List<INTUSManagement.Model.Order>>("/api/Orders");
        }
    }
}
