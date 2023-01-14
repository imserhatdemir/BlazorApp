using BlazorApp.Shared;

namespace BlazorApp.Server.Services.ContactAboutService
{
    public class ContactAboutService : IContactAboutService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContactAboutService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        private async Task<ContactAbout> GetSliderById(int id)
        {
            return await _context.ContactAbouts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ServiceResponse<List<ContactAbout>>> AddAbout(ContactAbout slider)
        {
            slider.Editing = slider.IsNew = false;
            _context.ContactAbouts.Add(slider);
            await _context.SaveChangesAsync();
            return await GetContactAdmin();
        }

        public async Task<ServiceResponse<ContactAbout>> AddCAboutNew(ContactAbout slider)
        {
            _context.ContactAbouts.Add(slider);
            await _context.SaveChangesAsync();
            return new ServiceResponse<ContactAbout> { Data = slider };
        }

        public async Task<ServiceResponse<List<ContactAbout>>> DeleteAbout(int id)
        {
            ContactAbout category = await GetSliderById(id);
            if (category == null)
            {
                return new ServiceResponse<List<ContactAbout>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }
            _context.ContactAbouts.Remove(category);
            await _context.SaveChangesAsync();

            return await GetContactAdmin();
        }

        public async Task<ServiceResponse<ContactAbout>> GetAbout(int id)
        {
            var response = new ServiceResponse<ContactAbout>();
            ContactAbout product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.ContactAbouts
                    .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            else
            {
                product = await _context.ContactAbouts
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

        public async Task<ServiceResponse<List<ContactAbout>>> GetContactAbout()
        {
            var about = await _context.ContactAbouts
                 .ToListAsync();
            return new ServiceResponse<List<ContactAbout>>
            {
                Data = about
            };
        }

        public async Task<ServiceResponse<List<ContactAbout>>> GetContactAdmin()
        {
            var categories = await _context.ContactAbouts
             .Where(c => !c.Deleted)
             .ToListAsync();
            return new ServiceResponse<List<ContactAbout>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<ContactAbout>>> UpdateAbout(ContactAbout slider)
        {
            var dbCategory = await _context.ContactAbouts
               
               .FirstOrDefaultAsync(p => p.Id == slider.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<ContactAbout>>
                {
                    Success = false,
                    Message = "About not found"
                };
            }
            dbCategory.Address = slider.Address;
            dbCategory.Location = slider.Location;
            dbCategory.Mail = slider.Mail;
            dbCategory.Visible = slider.Visible;

            await _context.SaveChangesAsync();
            return await GetContactAdmin();
        }
    }
}
