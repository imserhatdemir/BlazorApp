using MudBlazor;

namespace BlazorApp.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
           _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<Category>>> AddCategory(Category category)
        {
            
            category.Editing = category.IsNew = false;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return await GetAdminCategories();
        }

        public async Task<ServiceResponse<List<Category>>> DeleteCategory(int id)
        {
           Category category= await GetCategoryById(id);
            if (category == null)
            {
                return new ServiceResponse<List<Category>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }
            category.Deleted= true;
            await _context.SaveChangesAsync();

            return await GetAdminCategories();
        }

        private async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ServiceResponse<List<Category>>> GetAdminCategories()
        {
            var categories = await _context.Categories
                .Where(c => !c.Deleted)
                .Include(c => c.Images)
                 .Include(p => p.CategoryConnect.Where(v => !v.Deleted))
                    .ThenInclude(v => v.MainCategory)
                .ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<Category>>> GetCategories()
        {
            var categories = await _context.Categories
                .Where(c => !c.Deleted && c.Visible)
                .Include(c => c.Images)
                .Include(p => p.CategoryConnect.Where(v => !v.Deleted && v.Visible))
                    .ThenInclude(v => v.MainCategory)
                .ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data = categories
             };
        }

        public async Task<ServiceResponse<Category>> UpdateCategory(Category category)
        {
            //var dbCategory = await GetCategoryById(category.Id);
            //if (dbCategory == null)
            //{
            //    return new ServiceResponse<List<Category>>
            //    {
            //        Success = false,
            //        Message = "Category not found"
            //    };
            //}

            //dbCategory.Name = category.Name;
            //dbCategory.Url = category.Url;
            //dbCategory.Visible = category.Visible;
            //dbCategory.Featured = category.Featured;
            //dbCategory.ImageUrl = category.ImageUrl;

            //var productImages = dbCategory.Images;
            //_context.CategoryImages.RemoveRange(productImages);

            //dbCategory.Images = category.Images;
            //foreach (var variant in category.CategoryConnect)
            //{
            //    var dbVariant = await _context.CategoryConnects
            //        .SingleOrDefaultAsync(v => v.CategoryId == variant.CategoryId &&
            //            v.MainCategoryId == variant.MainCategoryId);
            //    if (dbVariant == null)
            //    {
            //        variant.MainCategory = null;
            //        _context.CategoryConnects.Add(variant);
            //    }
            //    else
            //    {
            //        dbVariant.MainCategoryId = variant.MainCategoryId;
            //        dbVariant.Url = variant.Url;
            //        dbVariant.Visible = variant.Visible;
            //        dbVariant.Deleted = variant.Deleted;

            //    }
            //}
            //await _context.SaveChangesAsync();
            //return await GetAdminCategories();

            var dbProduct = await GetCategoryById(category.Id);
            if (dbProduct == null)
            {
                return new ServiceResponse<Category>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            dbProduct.Name = category.Name;
            dbProduct.Visible = category.Visible;
            dbProduct.Featured = category.Featured;
            dbProduct.Url = category.Url;
            dbProduct.ImageUrl = category.ImageUrl;



            var productImages = dbProduct.Images;
            _context.CategoryImages.RemoveRange(productImages);


            dbProduct.Images = category.Images;

            foreach (var variant in category.CategoryConnect)
            {
                var dbVariant = await _context.CategoryConnects
                    .SingleOrDefaultAsync(v => v.CategoryId == variant.CategoryId &&
                        v.MainCategoryId == variant.MainCategoryId);
                if (dbVariant == null)
                {
                    variant.MainCategory = null;
                    _context.CategoryConnects.Add(variant);
                }
                else
                {
                    dbVariant.MainCategoryId = variant.MainCategoryId;
                    dbVariant.Url = variant.Url;
                    dbVariant.Visible = variant.Visible;
                    dbVariant.Deleted = variant.Deleted;

                }
            }
            await _context.SaveChangesAsync();
            return new ServiceResponse<Category> { Data = category };
        }



        public async Task<ServiceResponse<Category>> GetCategoryAsync(int catId)
        {
            var response = new ServiceResponse<Category>();
            Category product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Categories
                    .Include(p => p.CategoryConnect.Where(v => !v.Deleted))
                    .ThenInclude(v => v.MainCategory)
                    .Include(c => c.Images)
                    .FirstOrDefaultAsync(p => p.Id == catId && !p.Deleted);

            }
            else
            {
                product = await _context.Categories
                     .Include(p => p.CategoryConnect.Where(v => v.Visible && !v.Deleted))
                     .ThenInclude(v => v.MainCategory)
                     .Include(c => c.Images)
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

        public async Task<ServiceResponse<Category>> CreateCategory(Category category)
        {
            foreach (var variant in category.CategoryConnect)
            {
                variant.MainCategory = null;
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Category> { Data = category };
        }
    }
}
