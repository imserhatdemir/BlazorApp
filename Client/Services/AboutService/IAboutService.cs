namespace BlazorApp.Client.Services.AboutService
{
    public interface IAboutService
    {
        event Action OnChange;
        List<About> Abouts { get; set; }
        Task GetAbout();
    }
}
