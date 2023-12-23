using Microsoft.AspNetCore.Components;
using INTUSManagement.Model;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;
using System;
namespace INTUSBlazorWebAssemblyApp.Pages
{
    public class ElementBase : ComponentBase
    {
        [Inject]
        public HttpClient httpClient { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public INTUSManagement.Model.Element _element = new INTUSManagement.Model.Element();
        public List<INTUSManagement.Model.Element> Elements { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(async () => await Load());
        }

        private async Task Load()
        {
            Elements = await httpClient.GetFromJsonAsync<List<INTUSManagement.Model.Element>>("/api/Elements");
        }

        public async void Create()
        {

            try
            {
                var content = JsonSerializer.Serialize(_element);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("/api/Elements", bodyContent);

                if (response.IsSuccessStatusCode)
                {
                    Elements.Add(_element);
                    await Load();
                     NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}

