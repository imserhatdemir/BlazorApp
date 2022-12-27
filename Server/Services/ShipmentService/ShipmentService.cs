namespace BlazorApp.Server.Services.ShipmentService
{
    public class ShipmentService : IShipmentService
    {
        private readonly DataContext _context;

        public ShipmentService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<Shipment>> CreateShipment(Shipment ship)
        {
            
            _context.Shipments.Add(ship);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Shipment> { Data = ship };
        }

        public Task<ServiceResponse<bool>> DeleteShipment(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Shipment>>> GetAdminShipment()
        {
            var categories = await _context.Shipments
                .Where(c => !c.Deleted)
                .ToListAsync();
            return new ServiceResponse<List<Shipment>>
            {
                Data = categories
            };
        }

        public Task<ServiceResponse<ShipmentSearch>> SearchShipment(string searchText, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Shipment>>> UpdateShipment(Shipment ship)
        {
            var dbCategory = await GetShipById(ship.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Shipment>>
                {
                    Success = false,
                    Message = "About not found"
                };
            }
            dbCategory.Sender = ship.Sender;
            dbCategory.Weight = ship.Weight;
            dbCategory.ArrivalDate = ship.ArrivalDate;
            dbCategory.ShippingDate = ship.ShippingDate;
            dbCategory.OrderItems = ship.OrderItems;
            dbCategory.Recipient = ship.Recipient;
            dbCategory.TrackingNumber = ship.TrackingNumber;

            await _context.SaveChangesAsync();
            return await GetAdminShipment();
        }

        private async Task<Shipment> GetShipById(int id)
        {
            return await _context.Shipments.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
