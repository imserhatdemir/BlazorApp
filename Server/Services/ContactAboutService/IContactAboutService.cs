namespace BlazorApp.Server.Services.ContactAboutService
{
    public interface IContactAboutService
    {
        Task<ServiceResponse<List<ContactAbout>>> GetContactAbout();
    }
}
