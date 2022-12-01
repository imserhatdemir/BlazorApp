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

		public event Action OnChange;

		public async Task GetBrands()
		{
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Brand>>>("api/Brand");
            if (response != null && response.Data != null)
                Brands = response.Data;
        }
	}
}
