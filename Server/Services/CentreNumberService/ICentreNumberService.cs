namespace BlazorApp.Server.Services.CentreNumberService
{
    public interface ICentreNumberService
    {
        Task<ServiceResponse<List<CentreNumber>>> GetCentreNumber();
    }
}
