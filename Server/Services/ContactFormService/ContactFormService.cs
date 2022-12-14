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

        public async Task<ContactForm> CreateContact(ContactForm contact)
        {
             _context.ContactForms.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<ContactForm> DeleteContact(int id)
        {
            var contact = _context.ContactForms.FirstOrDefault(c => c.Id == id);
            _context.ContactForms.Remove(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public Task<List<ContactForm>> GetAllContacts()
        {
            var data = _context.ContactForms.ToListAsync();
            return data;
        }
    }
}
