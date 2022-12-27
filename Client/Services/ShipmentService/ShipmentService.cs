using BlazorApp.Client.Pages;
using BlazorApp.Client.Pages.Admin;
using BlazorApp.Shared;
using System.Net.Http;

namespace BlazorApp.Client.Services.ShipmentService
{
    public class ShipmentService : IShipmentService
    {
        private readonly HttpClient _http;

        public ShipmentService(HttpClient http)
        {
            _http = http;
        }
        public List<BlazorApp.Shared.Shipment> Shipments { get; set; } = new List<BlazorApp.Shared.Shipment>();
        public string Message { get; set; } = "loading..";

        public event Action OnChanged;

        public async Task<BlazorApp.Shared.Shipment> CreateShipment(BlazorApp.Shared.Shipment ship)
        {
            var result = await _http.PostAsJsonAsync("api/shipment", ship);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<BlazorApp.Shared.Shipment>>()).Data;
        }

        public Task DeleteShip(BlazorApp.Shared.Shipment shipId)
        {
            throw new NotImplementedException();
        }

        public async Task GetAdminShip()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<BlazorApp.Shared.Shipment>>>("api/shipment");
            if (response != null && response.Data != null)
                Shipments = response.Data;
        }

        public Task GetShipAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<BlazorApp.Shared.Shipment>> GetShipment(int shipId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateShip(BlazorApp.Shared.Shipment ship)
        {
            var response = await _http.PutAsJsonAsync("api/shipment/admin", ship);
            Shipments = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<BlazorApp.Shared.Shipment>>>()).Data;
            await GetAdminShip();
            OnChanged.Invoke();
        }
    }
}
