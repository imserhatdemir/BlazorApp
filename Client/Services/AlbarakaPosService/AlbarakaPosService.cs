using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.AlbarakaPosService
{

    public class AlbarakaPosService : IAlbarakaPosService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private const string ApiUrl = "https://epostest.albarakaturk.com.tr/ALBMerchantService/MerchantJSONAPI.svc";

        public AlbarakaPosService(HttpClient httpClient, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
        }

        public async Task<HttpResponseMessage> ProcessPayment(decimal amount, string cardNumber, string cardExpiry, string cardCVV)
        {
            var requestData = new
            {
                merchant_no = "6702640212",
                terminal_no = "67C16192",
                epos_no = "1010061899541024",
                enckey = "10,10,10,10,10,10,10,10",
                amount,
                cardNumber,
                cardExpiry,
                cardCVV
            };

            // 3D Secure sistem için istek gönderme
            var secureVerificationResponse = await _httpClient.PostAsJsonAsync("https://epostest.albarakaturk.com.tr/ALBSecurePaymentUI/SecureProcess/SecureVerification.aspx", requestData);
            if (!secureVerificationResponse.IsSuccessStatusCode)
            {
                throw new Exception($"SecureVerification request failed with status code: {secureVerificationResponse.StatusCode}");
            }

            // 3D Secure doğrulama aşamasını tamamlayan kullanıcı, satış işlemi için tekrar API'ye istek gönderir
            var saleResponse = await _httpClient.PostAsJsonAsync($"{ApiUrl}/Sale", requestData);
            if (!saleResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Sale request failed with status code: {saleResponse.StatusCode}");
            }

            return saleResponse;
        }
    
    private async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

    }
}
