namespace BlazorApp.Client.Services.ContactAboutService
{
    public interface IContactAboutService
    {
        event Action OnChange;
        List<ContactAbout> ContactAbouts { get; set; }
        Task GetContactAbout();
    }
}
