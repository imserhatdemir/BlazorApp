using BlazorApp.Client.Pages.Admin;
using BlazorApp.Shared;
using Stripe;

namespace BlazorApp.Server.Services.ContactFormService
{
    public class ContactFormService : IContactFormService
    {
        private readonly DataContext _context;

        public ContactFormService(DataContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<ContactForm>> CreateContact(ContactForm contact)
        {
            _context.ContactForms.Add(contact);
            await _context.SaveChangesAsync();
            return new ServiceResponse<ContactForm> { Data = contact };
        }

        public async Task<ServiceResponse<ContactForm>> DeleteContact(int Id)
        {
            var contact = _context.ContactForms.FirstOrDefault(c => c.Id == Id);
            _context.ContactForms.Remove(contact);
            await _context.SaveChangesAsync();
            return new ServiceResponse<ContactForm>();
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
    }
}
