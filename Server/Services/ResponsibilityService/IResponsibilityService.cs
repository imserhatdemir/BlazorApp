namespace BlazorApp.Server.Services.ResponsibilityService
{
    public interface IResponsibilityService
    {
        Task<ServiceResponse<List<Responsibility>>> GetResponsibility();
    }
}
