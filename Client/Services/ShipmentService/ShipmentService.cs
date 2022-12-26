using BlazorApp.Shared;

namespace BlazorApp.Client.Services.ShipmentService
{
    public class ShipmentService : IShipmentService
    {
        private readonly HttpClient _http;

        public ShipmentService(HttpClient http)
        {
            _http = http;
        }
        public List<Shipment> Shipments { get; set; } = new List<Shipment>();
        public string Message { get; set; } = "loading..";

        public event Action OnChanged;

        public async Task<Shipment> CreateShipment(Shipment ship)
        {
            var result = await _http.PostAsJsonAsync("api/shipment/admin", ship);
            return (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Shipment>>()).Data;
        }

        public Task DeleteShip(Shipment shipId)
        {
            throw new NotImplementedException();
        }

        public Task GetAdminShip()
        {
            throw new NotImplementedException();
        }

        public Task GetShipAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Shipment>> GetShipment(int shipId)
        {
            throw new NotImplementedException();
        }

        public Task<Shipment> UpdateShip(Shipment ship)
        {
            throw new NotImplementedException();
        }
    }
}
