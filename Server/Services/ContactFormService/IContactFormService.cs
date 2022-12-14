namespace BlazorApp.Server.Services.ContactFormService
{
    public interface IContactFormService
    {
        Task<ServiceResponse<List<ContactForm>>> GetContact();
        Task<ServiceResponse<ContactForm>> AddContact(ContactForm contact);
        Task<ServiceResponse<ContactForm>> DeleteContact(int id);
   }
}
