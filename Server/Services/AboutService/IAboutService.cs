namespace BlazorApp.Server.Services.AboutService
{
    public interface IAboutService
    {
        Task<ServiceResponse<List<About>>> GetAbout();
    }
}
