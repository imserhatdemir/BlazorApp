namespace BlazorApp.Client.Services.ContactFormService
{
    public interface IContactFormService
    {
        event Action OnChange;
        List<ContactForm> Contacts { get; set; }
    }
}
