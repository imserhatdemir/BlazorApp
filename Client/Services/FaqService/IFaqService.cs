namespace BlazorApp.Client.Services.FaqService
{
    public interface IFaqService
    {
        event Action OnChange;
        List<Faq> Faqs { get; set; }
        Task GetFaq();
    }
}
