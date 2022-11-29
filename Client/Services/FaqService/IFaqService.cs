namespace BlazorApp.Client.Services.FaqService
{
    public interface IFaqService
    {
        List<Faq> Faqs { get; set; }
        Task GetFaq();
    }
}
