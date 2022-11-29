namespace BlazorApp.Server.Services.FaqService
{
    public interface IFaqService
    {
        Task<ServiceResponse<List<Faq>>> GetFaq();
    }
}
