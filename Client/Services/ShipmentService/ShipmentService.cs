using BlazorApp.Client.Pages.Admin;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

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

        public List<Shipment> Shipments { get; set; } = new List<Shipment>();
        public string Message { get; set; } = "loading..";

        public event Action OnChanged;

        public async Task<Shipment> CreateShipment(Shipment ship)
        {
            var result = await _http.PostAsJsonAsync("api/shipment", ship);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Shipment>>()).Data;
        }

        public async Task DeleteShip(Shipment id)
        {
            var result = await _http.DeleteAsync($"api/shipment/{id.Id}/");
        }

        public async Task GetAdminShip()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Shipment>>>("api/shipment");
            if (response != null && response.Data != null)
                Shipments = response.Data;
        }

        public Task GetShipAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Shipment>> GetShipment(int id)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Shipment>>($"api/Shipment/{id}/");
            return result;
        }

        public async Task<Shipment> UpdateShip(Shipment ship)
        {
            var result = await _http.PutAsJsonAsync("api/shipment", ship);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<Shipment>>()).Data;
        }
    }
}
