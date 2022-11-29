namespace BlazorApp.Client.Services.FaqService
{
    public class FaqService : IFaqService
    {
        private readonly HttpClient _httpClient;

        public FaqService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Faq> Faqs { get; set; } = new List<Faq>();

        public async Task GetFaq()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Faq>>>("api/Faq");
            if (response != null && response.Data != null)
                Faqs = response.Data;
        }
    }
}
