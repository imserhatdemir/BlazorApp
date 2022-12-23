using BlazorApp.Client.Pages;
using BlazorApp.Client.Pages.Admin;
using BlazorApp.Client.Shared;
using BlazorApp.Shared;
using System.Net.Http;

namespace BlazorApp.Client.Services.SendMailService
{
    public class SendMailService : ISendMailService
    {
        private readonly HttpClient _http;

        public SendMailService(HttpClient http)
        {
            _http = http;
        }
        public string Message { get; set; }
        public List<SendMail> SendMails { get; set; } = new List<SendMail>();

        public event Action OnChange;

        public async Task<SendMail> CreateMail(SendMail send)
        {
            var result = await _http.PostAsJsonAsync("/api/SendMail", send);
            var newProduct = (await result.Content.ReadFromJsonAsync<ServiceResponse<SendMail>>()).Data;
            return newProduct;
        }

        public async Task DeleteMail(int id)
        {
            var result = await _http.DeleteAsync($"api/contact/{id}");
            await GetMail();
        }

        public async Task GetMail()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<SendMail>>>("/api/sendmail/admin");
                SendMails = response.Data;
        }
    }
}
