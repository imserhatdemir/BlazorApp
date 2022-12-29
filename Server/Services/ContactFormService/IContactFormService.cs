namespace BlazorApp.Server.Services.ContactFormService
{
    public interface IContactFormService
    {
        Task<ServiceResponse<List<ContactForm>>> GetContacts();
        Task<ServiceResponse<ContactForm>> GetContactasync(int id);
        Task<ServiceResponse<ContactForm>> CreateContact(ContactForm contact);
        Task<ServiceResponse<bool>> DeleteContact(int Id);
    }
}
