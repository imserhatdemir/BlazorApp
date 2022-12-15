namespace BlazorApp.Client.Services.ContactFormService
{
    public interface IContactFormService
    {
        event Action OnChange;
        List<ContactForm> Contacts { get; set; }
        Task GetContact();
        Task DeleteContact(int id);
        Task CreateContact(ContactForm contact);
    }
}
