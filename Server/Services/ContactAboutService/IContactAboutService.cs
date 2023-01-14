namespace BlazorApp.Server.Services.ContactAboutService
{
    public interface IContactAboutService
    {
        Task<ServiceResponse<List<ContactAbout>>> GetContactAbout();
        Task<ServiceResponse<List<ContactAbout>>> GetContactAdmin();
        Task<ServiceResponse<List<ContactAbout>>> AddAbout(ContactAbout slider);
        Task<ServiceResponse<ContactAbout>> AddCAboutNew(ContactAbout slider);
        Task<ServiceResponse<List<ContactAbout>>> UpdateAbout(ContactAbout slider);
        Task<ServiceResponse<List<ContactAbout>>> DeleteAbout(int id);
        Task<ServiceResponse<ContactAbout>> GetAbout(int id);
    }
}
