using BlazorApp.Shared;

namespace BlazorApp.Server.Services.BrandService
{
	public class BrandService : IBrandService
	{
		private readonly DataContext _context;

		public BrandService(DataContext context)
		{
			_context = context;
		}

        private async Task<Brand> GetBrandById(int id)
        {
            return await _context.Brands.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ServiceResponse<List<Brand>>> AddBrand(Brand brand)
		{
            brand.Editing = brand.IsNew = false;
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return await GetAdminBrands();
        }

		public async Task<ServiceResponse<List<Brand>>> DeleteBrand(int id)
		{
            Brand brand = await GetBrandById(id);
            if (brand == null)
            {
                return new ServiceResponse<List<Brand>>
                {
                    Success = false,
                    Message = "Brand not found"
                };
            }
            brand.Deleted = true;
            await _context.SaveChangesAsync();

            return await GetAdminBrands();
        }

		public async Task<ServiceResponse<List<Brand>>> GetAdminBrands()
		{
            var categories = await _context.Brands
                .Where(c => !c.Deleted)
                .ToListAsync();
            return new ServiceResponse<List<Brand>>
            {
                Data = categories
            };
        }

		public async Task<ServiceResponse<List<Brand>>> GetBrands()
		{
            var brand = await _context.Brands
               
                .ToListAsync();
            return new ServiceResponse<List<Brand>>
            {
                Data = brand
            };
        }

		public async Task<ServiceResponse<List<Brand>>> UpdateBrand(Brand brand)
		{
            var dbCategory = await GetBrandById(brand.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Brand>>
                {
                    Success = false,
                    Message = "Brand not found"
                };
            }

            dbCategory.Title = brand.Title;
            dbCategory.ImageUrl = brand.ImageUrl;
            dbCategory.Visible = brand.Visible;

            await _context.SaveChangesAsync();
            return await GetAdminBrands();
        }
	}
}
