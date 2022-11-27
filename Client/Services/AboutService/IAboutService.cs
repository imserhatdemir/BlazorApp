namespace BlazorApp.Client.Services.AboutService
{
    public interface IAboutService
    {
        List<About> Abouts { get; set; }
        Task GetAbout();
    }
}
