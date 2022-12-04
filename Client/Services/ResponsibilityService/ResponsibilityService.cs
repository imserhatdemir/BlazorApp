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
        public List<Responsibility> AdminResponsibilities { get; set; } = new List<Responsibility>();

        public event Action OnChange;

        public async Task AddResponsibility(Responsibility responsibility)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Responsibility/admin", responsibility);
            AdminResponsibilities = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Responsibility>>>()).Data;
            await GetResponsibility();
            OnChange.Invoke();
        }

        public Responsibility CreateNewResp()
        {
            var newCategory = new Responsibility { IsNew = true, Editing = true };
            AdminResponsibilities.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task GetAdminResp()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Responsibility>>>("api/Responsibility/admin");
            if (response != null && response.Data != null)
                AdminResponsibilities = response.Data;
        }

        public async Task GetResponsibility()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Responsibility>>>("api/Responsibility");
            if (response != null && response.Data != null)
                Responsibilities = response.Data;
        }

        public async Task UpdateResponsibility(Responsibility responsibility)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Responsibility/admin", responsibility);
            AdminResponsibilities = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Responsibility>>>()).Data;
            await GetAdminResp();
            OnChange.Invoke();
        }
    }
}
