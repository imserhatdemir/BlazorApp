namespace BlazorApp.Server.Services.ShipmentService
{
    public class ShipmentService : IShipmentService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShipmentService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ServiceResponse<Shipment>> CreateShipment(Shipment ship)
        {
            
            _context.Shipments.Add(ship);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Shipment> { Data = ship };
        }

        public async Task<ServiceResponse<List<Shipment>>> DeleteShip(int id)
        {
            Shipment category = await GetShipById(id);
            if (category == null)
            {
                return new ServiceResponse<List<Shipment>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }
            category.Deleted = true;
            await _context.SaveChangesAsync();
            return await GetAdminShipment();
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

        public async Task<ServiceResponse<Shipment>> GetShipment(int id)
        {
            var response = new ServiceResponse<Shipment>();
            Shipment product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Shipments
                    .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            else
            {
                product = await _context.Shipments
                     .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public Task<ServiceResponse<ShipmentSearch>> SearchShipment(string searchText, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Shipment>> UpdateShipment(Shipment ship)
        {
            var dbCategory = await GetShipById(ship.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<Shipment>
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
            return new ServiceResponse<Shipment> { Data = ship };
        }

        private async Task<Shipment> GetShipById(int id)
        {
            return await _context.Shipments.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
