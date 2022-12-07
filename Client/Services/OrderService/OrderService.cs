using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly NavigationManager _navigationManager;
        private readonly IAuthService _authService;

        public OrderService( HttpClient http, AuthenticationStateProvider authStateProvider, NavigationManager navigationManager,IAuthService authService)
        {
            
            _http = http;
            _authStateProvider = authStateProvider;
            _navigationManager = navigationManager;
            _authService = authService;
        }

        public async Task<OrderDetailsResponse> GetAdminOrderDetails(int orderId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<OrderDetailsResponse>>($"api/order/admin/{orderId}");
            return result.Data;
        }

        public async Task<List<OrderOverviewResponse>> GetAdminOrders()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order/admin");
            return result.Data;
        }

        public async Task<OrderDetailsResponse> GetOrderDetails(int orderId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<OrderDetailsResponse>>($"api/order/{orderId}");
            return result.Data;
        }

        public async Task<List<OrderOverviewResponse>> GetOrders()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");
            return result.Data;
        }

        public async Task<string> PlaceOrder()
        {
            if(await IsUserAuthenticated())
            {
                var result=await _http.PostAsync("api/payment/checkout", null);
                var url=await result.Content.ReadAsStringAsync();
                return url;
            }
            else
            {
                return "login";
            }
        }


        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }
    }
}
