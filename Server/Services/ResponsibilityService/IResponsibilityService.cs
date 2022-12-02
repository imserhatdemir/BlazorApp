namespace BlazorApp.Server.Services.ResponsibilityService
{
    public interface IResponsibilityService
    {
        Task<ServiceResponse<List<Responsibility>>> GetResponsibility();
        Task<ServiceResponse<List<Responsibility>>> GetAdminResp();
        Task<ServiceResponse<List<Responsibility>>> AddResp(Responsibility responsibility);
        Task<ServiceResponse<List<Responsibility>>> UpdateResp(Responsibility responsibility);
    }
}
