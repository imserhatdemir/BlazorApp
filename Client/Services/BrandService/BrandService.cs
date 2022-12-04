using BlazorApp.Shared;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.BrandService
{
	public class BrandService : IBrandService
	{
		private readonly HttpClient _httpClient;

		public BrandService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public List<Brand> Brands { get; set; } = new List<Brand>();
		public List<Brand> AdminBrands { get; set; } = new List<Brand>();

        public event Action OnChange;
		public async Task AddBrands(Brand brand)
		{
			var response = await _httpClient.PostAsJsonAsync("api/Brand/admin", brand);
            AdminBrands = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Brand>>>()).Data;
            await GetBrands();
            OnChange.Invoke();
        }

		public Brand CreateNewBrand()
		{
            var newCategory = new Brand { IsNew = true, Editing = true };
            AdminBrands.Add(newCategory);
            OnChange.Invoke();
            return newCategory;
        }

		public async Task DeleteBrands(int brandId)
		{
            var response = await _httpClient.DeleteAsync($"api/Brand/admin/{brandId}");
            AdminBrands = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Brand>>>()).Data;
            await GetBrands();
            OnChange.Invoke();
        }

		public async Task GetAdminBrands()
		{
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Brand>>>("api/Brand/admin");
            if (response != null && response.Data != null)
                AdminBrands = response.Data;
        }

		public async Task GetBrands()
		{
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Brand>>>("api/Brand");
            if (response != null && response.Data != null)
                Brands = response.Data;
        }

		public async Task UpdateBrands(Brand brand)
		{
            var response = await _httpClient.PutAsJsonAsync("api/Brand/admin", brand);
            AdminBrands = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<Brand>>>()).Data;
            await GetBrands();
            OnChange.Invoke();
        }
	}
}
