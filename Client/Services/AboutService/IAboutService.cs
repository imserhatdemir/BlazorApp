namespace BlazorApp.Client.Services.AboutService
{
    public interface IAboutService
    {
        event Action OnChange;
        List<About> Abouts { get; set; }
        List<About> AdminAbouts { get; set; }
        Task GetAbout();
        Task GetAdminAbout();
        Task UpdateAbout(About about);
        Task AddAbout(About about);
        About CreateNewAbout();
    }
}
