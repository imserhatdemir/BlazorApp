namespace BlazorApp.Server.Services.ContactFormService
{
    public interface IContactFormService
    {
        Task<ServiceResponse<List<ContactForm>>> GetContacts();
        Task<ServiceResponse<ContactForm>> CreateContact(ContactForm contact);
        Task<ServiceResponse<ContactForm>> DeleteContact(int Id);
    }
}
