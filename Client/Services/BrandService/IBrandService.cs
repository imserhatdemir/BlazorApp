namespace BlazorApp.Client.Services.BrandService
{
	public interface IBrandService
	{
        event Action OnChange;
        List<Brand> Brands { get; set; }
        List<Brand> AdminBrands { get; set; }
        Task GetBrands();
        Task GetAdminBrands();
        Task DeleteBrands(int brandId);
        Task UpdateBrands(Brand brand);
        Task AddBrands(Brand brand);
        Brand CreateNewBrand();
    }
}
