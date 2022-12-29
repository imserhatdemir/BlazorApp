namespace BlazorApp.Client.Services.ContactFormService
{
    public interface IContactFormService
    {
        event Action OnChange;
        List<ContactForm> Contacts { get; set; }
        string Message { get; set; }
        Task GetContactAsync();
        Task<ContactForm> CreateContact(ContactForm contact);
        Task DeleteContact(ContactForm contactId);
        Task<ServiceResponse<ContactForm>> GetContacts(int id);

    }
}
