namespace BlazorApp.Server.Services.FaqService
{
    public interface IFaqService
    {
        Task<ServiceResponse<List<Faq>>> GetFaq();
        Task<ServiceResponse<List<Faq>>> GetAdminFaq();
        Task<ServiceResponse<List<Faq>>> AddFaq(Faq faq);
        Task<ServiceResponse<Faq>> AddNewFaq(Faq faq);
        Task<ServiceResponse<List<Faq>>> UpdateFaq(Faq faq);
        Task<ServiceResponse<List<Faq>>> DeleteFaq(int id);
        Task<ServiceResponse<Faq>> GetFaqById(int id);
    }
}
