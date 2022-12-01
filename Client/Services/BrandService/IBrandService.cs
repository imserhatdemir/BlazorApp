namespace BlazorApp.Client.Services.BrandService
{
	public interface IBrandService
	{
        event Action OnChange;
        List<Brand> Brands { get; set; }
        Task GetBrands();
    }
}
