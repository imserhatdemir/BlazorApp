namespace BlazorApp.Server.Services.SendMailService
{
    public interface ISendMailService
    {
        Task<ServiceResponse<List<SendMail>>> GetMail();
        Task<ServiceResponse<SendMail>> AddMail(SendMail send);
        Task<ServiceResponse<SendMail>> DeleteMail(int id);
    }
}
