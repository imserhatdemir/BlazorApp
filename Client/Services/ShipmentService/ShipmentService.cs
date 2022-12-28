using BlazorApp.Client.Pages;
using BlazorApp.Client.Pages.Admin;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace BlazorApp.Client.Services.ShipmentService
{
    public class ShipmentService : IShipmentService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ShipmentService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
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

        public async Task DeleteShip(int id)
        {
            var response = await _http.DeleteAsync($"api/Shipment/{id}");
            Shipments = (await response.Content.ReadFromJsonAsync<ServiceResponse<List<BlazorApp.Shared.Shipment>>>()).Data;
            await GetAdminShip();
            OnChanged.Invoke();

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

        public async Task<ServiceResponse<BlazorApp.Shared.Shipment>> GetShipment(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<BlazorApp.Shared.Shipment>>($"api/Shipment/{id}/");
            return result;
        }

        public async Task<BlazorApp.Shared.Shipment> UpdateShip(BlazorApp.Shared.Shipment ship)
        {
            var result = await _http.PutAsJsonAsync("api/shipment", ship);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<BlazorApp.Shared.Shipment>>()).Data;
        }
    }
}
