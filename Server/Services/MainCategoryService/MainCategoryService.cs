namespace BlazorApp.Server.Services.MainCategoryService
{
    public class MainCategoryService : IMainCategoryService
    {
        private readonly DataContext _context;

        public MainCategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MainCategory>>> AddMainCategory(MainCategory category)
        {
            category.Editing = category.IsNew = false;
            _context.MainCategories.Add(category);
            await _context.SaveChangesAsync();
            return await GetAdminMainCategories();
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
               .Where(c => !c.Deleted).Include(c=>c.Categories)
               .ToListAsync();
            return new ServiceResponse<List<MainCategory>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<MainCategory>>> GetMainCategory()
        {
            var categories = await _context.MainCategories
               .Where(c => !c.Deleted && c.Visible).Include(c => c.Categories)
               .ToListAsync();
            return new ServiceResponse<List<MainCategory>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<MainCategory>>> UpdateMainCategory(MainCategory category)
        {
            var dbCategory = await GetCategoryById(category.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<MainCategory>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            dbCategory.Name = category.Name;
            dbCategory.Visible = category.Visible;
            dbCategory.Featured = category.Featured;


            await _context.SaveChangesAsync();
            return await GetAdminMainCategories();
        }


        private async Task<MainCategory> GetCategoryById(int id)
        {
            return await _context.MainCategories.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
