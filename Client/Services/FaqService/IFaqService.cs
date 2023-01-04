namespace BlazorApp.Client.Services.FaqService
{
    public interface IFaqService
    {
        event Action OnChange;
        List<Faq> Faqs { get; set; }
        Task GetFaq();
        List<Faq> AdminFaq { get; set; }
        Task GetAdminFaq();
        Task DeleteFaq(int id);
        Task UpdateFaq(Faq faq);
        Task AddFaq(Faq faq);
        Faq CreateNewFaq();
        Task<ServiceResponse<Faq>> GetFaqById(int id);
        Task<Faq> AddNewFaq(Faq faq);
    }
}
