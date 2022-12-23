namespace BlazorApp.Client.Services.SendMailService
{
    public interface ISendMailService
    {
        event Action OnChange;
        List<SendMail> SendMails { get; set; }
        string Message { get; set; }
        Task GetMail();
        Task<SendMail> CreateMail(SendMail send);
        Task DeleteMail(int id);
    }
}
