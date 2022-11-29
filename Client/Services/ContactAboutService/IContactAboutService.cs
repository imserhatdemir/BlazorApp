namespace BlazorApp.Client.Services.ContactAboutService
{
    public interface IContactAboutService
    {
        List<ContactAbout> ContactAbouts { get; set; }
        Task GetContactAbout();
    }
}
