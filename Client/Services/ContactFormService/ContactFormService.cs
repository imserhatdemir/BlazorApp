namespace BlazorApp.Client.Services.ContactFormService
{
    public class ContactFormService : IContactFormService
    {
        public List<ContactForm> Contacts { get ; set; }

        public event Action OnChange;
    }
}
