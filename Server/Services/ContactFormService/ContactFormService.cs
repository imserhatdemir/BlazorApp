using BlazorApp.Client.Pages.Admin;
using BlazorApp.Shared;
using Stripe;

namespace BlazorApp.Server.Services.ContactFormService
{
    public class ContactFormService : IContactFormService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContactFormService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
           _httpContextAccessor = httpContextAccessor;
        }


        public async Task<ServiceResponse<ContactForm>> CreateContact(ContactForm contact)
        {
            _context.ContactForms.Add(contact);
            await _context.SaveChangesAsync();
            return new ServiceResponse<ContactForm> { Data = contact };
        }

 

        public async Task<ServiceResponse<List<ContactForm>>> GetContacts()
        {
            var response = new ServiceResponse<List<ContactForm>>
            {
                Data = await _context.ContactForms
                .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteContact(int Id)
        {
            var dbProduct = await GetShipById(Id);
            if (dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Product not found"
                };
            }
            _context.ContactForms.Remove(dbProduct);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }


        private async Task<ContactForm> GetShipById(int id)
        {
            return await _context.ContactForms.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ServiceResponse<ContactForm>> GetContactasync(int id)
        {
            var response = new ServiceResponse<ContactForm>();
            ContactForm product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.ContactForms
                    .FirstOrDefaultAsync(p => p.Id == id);

            }
            else
            {
                product = await _context.ContactForms
                     .FirstOrDefaultAsync(p => p.Id == id);

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
    }
}
