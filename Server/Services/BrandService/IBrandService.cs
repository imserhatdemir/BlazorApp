namespace BlazorApp.Server.Services.BrandService
{
	public interface IBrandService
	{
        Task<ServiceResponse<List<Brand>>> GetBrands();
        Task<ServiceResponse<List<Brand>>> GetAdminBrands();
        Task<ServiceResponse<List<Brand>>> AddBrand(Brand brand);
        Task<ServiceResponse<List<Brand>>> UpdateBrand(Brand brand);
        Task<ServiceResponse<List<Brand>>> DeleteBrand(int id);
    }
}
