using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text;

namespace INTUSBlazorWebAssemblyApp.Pages
{
    public class OrderBase: ComponentBase
    {
        [Inject]
        public HttpClient httpClient { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<INTUSManagement.Model.Element> elements { get; set; }

        public INTUSManagement.Model.Order _order = new INTUSManagement.Model.Order();
        public INTUSManagement.Model.Window _window = new INTUSManagement.Model.Window();
        public INTUSManagement.Model.SubElement _subElement = new INTUSManagement.Model.SubElement();

        public int subLength = 0;
        public bool createWindowBtn = false;
        public bool createElementBtn = false;
        public int countElement = 0;
        protected override async Task OnInitializedAsync()
        {
            await Task.Run(async () => await Load());
        }

        private async Task Load()
        {
            elements = await httpClient.GetFromJsonAsync<List<INTUSManagement.Model.Element>>("/api/Elements");
        }

        public void OnSelectionChange(ChangeEventArgs args)
        {
            var selectedElementId = Convert.ToInt32(args.Value);

            // Find the selected element based on its id
            var temp = elements.FirstOrDefault(e => e.ElementId == selectedElementId);
            _subElement.Type = temp.Type;
            _subElement.Width = temp.Width;
            _subElement.Height = temp.Height;
          
        }
        public void openWindowFrom()
        {
            this.countElement = 0;
            this.createWindowBtn = true;

        }

        public async void CreateOrder()
        {
            try
            {
                var content = JsonSerializer.Serialize(_order);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("/api/Orders", bodyContent);

                if (response.IsSuccessStatusCode)
                {
                   
                   
                   // NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        public void CreateWindow()
        {
           if( this.createElementBtn == false && _window.TotalSubElements > 0)
            {
                this.createElementBtn = true;
            }
        }

        public void CreateSubElement()
        {
            this.countElement++;

            _window.SubElements.Add(_subElement);
            _subElement = new INTUSManagement.Model.SubElement();


            if (_window.TotalSubElements == countElement)
            {
                this.createWindowBtn = false;
                this.createElementBtn = false;

                this._order.Windows.Add(_window);
                _window = new INTUSManagement.Model.Window();
            }

            

        }
    }
}
