namespace BlazorApp.Client.Services.MainCategoryService
{
    public class MainCategoryService : IMainCategoryService
    {
        private readonly HttpClient _http;

        public MainCategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<MainCategory> MainCategories { get; set; } = new List<MainCategory>();
        public List<MainCategory> AdminMainCategories { get; set; } = new List<MainCategory>();

        public event Action OnChange;

        public async Task AddMainCategories(MainCategory category)
        {
            var response = await _http.PostAsJsonAsync("api/MainCategory/admin", category);
            AdminMainCategories = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<MainCategory>>>()).Data;
            OnChange.Invoke();
        }

        public MainCategory CreateNewMainCategory()
        {
            var newCategory = new MainCategory 
            { IsNew = true, Editing = true };
            AdminMainCategories.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task DeleteMainCategories(int categoryId)
        {
            var response = await _http.DeleteAsync($"api/MainCategory/admin/{categoryId}");
            AdminMainCategories = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<MainCategory>>>()).Data;
            await GetAdminMainCategories();
            OnChange.Invoke();
        }

        public async Task GetAdminMainCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<MainCategory>>>("api/MainCategory/admin");
            if (response != null && response.Data != null)
                AdminMainCategories = response.Data;
        }

        public async Task GetMainCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<MainCategory>>>("api/MainCategory");
            if (response != null && response.Data != null)
                MainCategories = response.Data;
        }

        public async Task<MainCategory> UpdateCategories(MainCategory category)
        {
            var result = await _http.PutAsJsonAsync("api/Maincategory", category);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<MainCategory>>()).Data;
        }
    }
}
