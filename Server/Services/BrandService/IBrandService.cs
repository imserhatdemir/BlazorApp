namespace BlazorApp.Server.Services.BrandService
{
	public interface IBrandService
	{
        Task<ServiceResponse<List<Brand>>> GetBrands();
    }
}
