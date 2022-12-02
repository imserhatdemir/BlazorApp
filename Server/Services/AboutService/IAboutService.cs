namespace BlazorApp.Server.Services.AboutService
{
    public interface IAboutService
    {
        Task<ServiceResponse<List<About>>> GetAbout();
        Task<ServiceResponse<List<About>>> GetAdminAbout();
        Task<ServiceResponse<List<About>>> AddAbout(About about);
        Task<ServiceResponse<List<About>>> UpdateAbout(About about);
    }
}
