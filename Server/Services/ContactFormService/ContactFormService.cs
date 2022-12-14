using BlazorApp.Shared;

namespace BlazorApp.Server.Services.ContactFormService
{
    public class ContactFormService : IContactFormService
    {
        private readonly DataContext _context;

        public ContactFormService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<ContactForm>> AddContact(ContactForm contact)
        {
            _context.ContactForms.Add(contact);
            await _context.SaveChangesAsync(); 
            return await GetContact();
        }

        public async Task<ServiceResponse<ContactForm>> DeleteContact(int id)
        {
            var deleteContact = await _context.ContactForms.FirstOrDefaultAsync(a=>a.Id== id);
            _context.ContactForms.Remove(deleteContact);
            await _context.SaveChangesAsync();
            return await GetContact();
        }

        public Task<ServiceResponse<List<ContactForm>>> GetContact()
        {
            throw new NotImplementedException();
        }
    }
}
