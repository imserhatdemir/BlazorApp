using BlazorApp.Shared;

namespace BlazorApp.Server.Services.FaqService
{
    public class FaqService : IFaqService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FaqService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private async Task<Faq> FaqById(int id)
        {
            return await _context.Faqs.FirstOrDefaultAsync(c => c.Id == id);
        }

        
        public async Task<ServiceResponse<List<Faq>>> AddFaq(Faq faq)
        {
            faq.Editing = faq.IsNew = false;
            _context.Faqs.Add(faq);
            await _context.SaveChangesAsync();
            return await GetAdminFaq();
        }

        public Task<ServiceResponse<Faq>> AddNewFaq(Faq faq)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Faq>>> DeleteFaq(int id)
        {
            Faq category = await FaqById(id);
            if (category == null)
            {
                return new ServiceResponse<List<Faq>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }
            _context.Faqs.Remove(category);
            await _context.SaveChangesAsync();

            return await GetAdminFaq();
        }

        public async Task<ServiceResponse<List<Faq>>> GetAdminFaq()
        {
            var categories = await _context.Faqs
                          .Where(c => !c.Deleted)
                          .ToListAsync();
            return new ServiceResponse<List<Faq>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<Faq>>> GetFaq()
        {
            var about = await _context.Faqs
                .ToListAsync();
            return new ServiceResponse<List<Faq>>
            {
                Data = about
            };
        }

        public async Task<ServiceResponse<Faq>> GetFaqById(int id)
        {
            var response = new ServiceResponse<Faq>();
            Faq product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Faqs
                    .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            else
            {
                product = await _context.Faqs
                     .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

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

        public async Task<ServiceResponse<List<Faq>>> UpdateFaq(Faq faq)
        {
            var dbCategory = await FaqById(faq.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Faq>>
                {
                    Success = false,
                    Message = "About not found"
                };
            }
            dbCategory.Title = faq.Title;
            dbCategory.Description = faq.Description;
            dbCategory.Visible = faq.Visible;

            await _context.SaveChangesAsync();
            return await GetAdminFaq();
        }
    }
}
