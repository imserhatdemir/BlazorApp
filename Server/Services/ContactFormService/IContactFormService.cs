namespace BlazorApp.Server.Services.ContactFormService
{
    public interface IContactFormService
    {
        Task<ContactForm> CreateContact(ContactForm contact);
        Task<List<ContactForm>> GetAllContacts();
        Task<ContactForm> DeleteContact(int id);
   }
}
