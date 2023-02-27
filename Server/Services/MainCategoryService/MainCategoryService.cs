namespace BlazorApp.Server.Services.MainCategoryService
{
    public class MainCategoryService : IMainCategoryService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MainCategoryService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<MainCategory>>> AddMainCategory(MainCategory category)
        {
            category.Editing = category.IsNew = false;
            _context.MainCategories.Add(category);
            await _context.SaveChangesAsync();
            return await GetAdminMainCategories();
        }

        public async Task<ServiceResponse<MainCategory>> CreateMainCategory(MainCategory category)
        {
            _context.MainCategories.Add(category);
            await _context.SaveChangesAsync();
            return new ServiceResponse<MainCategory> { Data = category };
        }

        public async Task<ServiceResponse<List<MainCategory>>> DeleteMainCategory(int id)
        {
            MainCategory category = await GetCategoryById(id);
            if (category == null)
            {
                return new ServiceResponse<List<MainCategory>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }
            category.Deleted = true;
            await _context.SaveChangesAsync();

            return await GetAdminMainCategories();
        }

        public async Task<ServiceResponse<List<MainCategory>>> GetAdminMainCategories()
        {
            var categories = await _context.MainCategories
                .Where(c => !c.Deleted)
                .ToListAsync();
            return new ServiceResponse<List<MainCategory>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<MainCategory>>> GetMainCategories()
        {
            var categories = await _context.MainCategories
               .Where(c => !c.Deleted && c.Visible)
               .ToListAsync();
            return new ServiceResponse<List<MainCategory>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<MainCategory>> GetMainCategoryAsync(int catId)
        {
            var response = new ServiceResponse<MainCategory>();
            MainCategory product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.MainCategories
                    .FirstOrDefaultAsync(p => p.Id == catId && !p.Deleted);

            }
            else
            {
                product = await _context.MainCategories
                     .FirstOrDefaultAsync(p => p.Id == catId && !p.Deleted && p.Visible);

            }
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<MainCategory>> UpdateMainCategory(MainCategory category)
        {
            var dbProduct = await GetCategoryById(category.Id);
            if (dbProduct == null)
            {
                return new ServiceResponse<MainCategory>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            dbProduct.Name = category.Name;
            dbProduct.Visible = category.Visible;
            dbProduct.Featured = category.Featured;
            dbProduct.Url = category.Url;



            await _context.SaveChangesAsync();
            return new ServiceResponse<MainCategory> { Data = category };
        }

        private async Task<MainCategory> GetCategoryById(int id)
        {
            return await _context.MainCategories.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
