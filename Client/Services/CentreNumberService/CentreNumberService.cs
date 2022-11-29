using BlazorApp.Shared;

namespace BlazorApp.Client.Services.CentreNumberService
{
    public class CentreNumberService : ICentreNumberService
    {
        private readonly HttpClient _httpClient;

        public CentreNumberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<CentreNumber> CentreNumbers { get; set; } = new List<CentreNumber>();

        public async Task GetCentreNumber()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<CentreNumber>>>("api/CentreNumber");
            if (response != null && response.Data != null)
                CentreNumbers = response.Data;
        }
    }
}
