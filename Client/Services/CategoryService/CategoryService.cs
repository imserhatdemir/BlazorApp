using BlazorApp.Client.Pages.Admin;
using BlazorApp.Shared;

namespace BlazorApp.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Category> AdminCategories { get; set; } = new List<Category>();

        public event Action OnChange;

        public async Task AddCategories(Category category)
        {
            var response = await _http.PostAsJsonAsync("api/Category/admin",category);
            AdminCategories = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Data;
            await GetCategories();
            OnChange.Invoke();
        }

        public async Task<Category> CreateCategory(Category category)
        {
            var result = await _http.PostAsJsonAsync("api/category", category);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Category>>()).Data;
        }

        public Category CreateNewCategory()
        {
            var newCategory = new Category { IsNew = true,Editing=true};
            AdminCategories.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

        public async Task DeleteCategories(int categoryId)
        {
            var response = await _http.DeleteAsync($"api/Category/admin/{categoryId}");
            AdminCategories = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Category>>>()).Data;
            await GetCategories();
            OnChange.Invoke();
        }

        public async Task GetAdminCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category/admin");
            if (response != null && response.Data != null)
                AdminCategories = response.Data;
        }

        public async Task GetCategories()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if (response != null && response.Data != null)
            Categories = response.Data;
        }

        public async Task<ServiceResponse<Category>> GetCategory(int catId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Category>>($"api/Category/{catId}/");
            return result;
        }

        public async Task<Category> UpdateCategories(Category category)
        {
            var result = await _http.PutAsJsonAsync("api/Category", category);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<Category>>()).Data;
        }
    }
}
