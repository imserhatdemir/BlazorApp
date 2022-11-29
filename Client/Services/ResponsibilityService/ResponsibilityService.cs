namespace BlazorApp.Client.Services.ResponsibilityService
{
    public class ResponsibilityService : IResponsibilityService
    {
        private readonly HttpClient _httpClient;

        public ResponsibilityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Responsibility> Responsibilities { get; set; } = new List<Responsibility>();

        public async Task GetResponsibility()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Responsibility>>>("api/Responsibility");
            if (response != null && response.Data != null)
                Responsibilities = response.Data;
        }
    }
}
