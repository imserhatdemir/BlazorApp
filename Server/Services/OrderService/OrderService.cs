﻿using System.Security.Claims;

namespace BlazorApp.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {

        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

        public OrderService(DataContext context, ICartService cartService,IAuthService authService)
        {
            _context = context;
            _cartService = cartService;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<OrderOverviewResponse>>> GetAdminOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponse>>();
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponse>();
            orders.ForEach(o => orderResponse.Add(new OrderOverviewResponse
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Product = o.OrderItems.Count > 1 ? $"{o.OrderItems.First().Product.Title} and" + $"{o.OrderItems.Count - 1} more..." : o.OrderItems.First().Product.Title,
                ProductImageUrl = o.OrderItems.First().Product.ImageURL,

            }));

            response.Data = orderResponse;

            return response;
        }

        public async Task<ServiceResponse<OrderDetailsResponse>> GetAdminOrdersDetails(int orderId)
        {
            var response = new ServiceResponse<OrderDetailsResponse>();
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(os => os.Product)
                .Include(o => o.OrderItems)
                .ThenInclude(os => os.ProductType)
                .Where(o => o.Id == orderId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync();


            if (order == null)
            {
                response.Success = false;
                response.Message = "Order not found";
                return response;
            }

            var orderDetailsResponse = new OrderDetailsResponse
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Products = new List<OrderDetailsProductResponse>()
            };

            order.OrderItems.ForEach(item =>
            orderDetailsResponse.Products.Add(new OrderDetailsProductResponse
            {
                ProductId = item.ProductId,
                ImageUrl = item.Product.ImageURL,
                ProductType = item.ProductType.Name,
                Quantity = item.Quantity,
                Title = item.Product.Title,
                TotalPrice = item.TotalPrice
            }
            ));


            response.Data = orderDetailsResponse;
            return response;
        }

        public async Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponse>>();
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == _authService.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewResponse>();
            orders.ForEach(o => orderResponse.Add(new OrderOverviewResponse
            {
                Id=o.Id,
                OrderDate=o.OrderDate,
                TotalPrice=o.TotalPrice,
                Product=o.OrderItems.Count > 1 ? $"{o.OrderItems.First().Product.Title} and" + $"{o.OrderItems.Count-1} more...": o.OrderItems.First().Product.Title,
                ProductImageUrl=o.OrderItems.First().Product.ImageURL
            }));

            response.Data=orderResponse;

            return response;
        }

        public async Task<ServiceResponse<OrderDetailsResponse>> GetOrdersDetails(int orderId)
        {
           var response =new ServiceResponse<OrderDetailsResponse>(); 
            var order = await _context.Orders
                .Include(o=>o.OrderItems)
                .ThenInclude(os=>os.Product)
                .Include(o =>o.OrderItems)
                .ThenInclude(os=>os.ProductType)
                .Where(o=>o.UserId==_authService.GetUserId() && o.Id==orderId)
                .OrderByDescending(o=>o.OrderDate)
                .FirstOrDefaultAsync();


            if (order == null)
            {
                response.Success=false;
                response.Message = "Order not found";
                return response;
            }

            var orderDetailsResponse = new OrderDetailsResponse
            {
                OrderDate = order.OrderDate,
                TotalPrice=order.TotalPrice,
                Products=new List<OrderDetailsProductResponse>()
            };

            order.OrderItems.ForEach(item =>
            orderDetailsResponse.Products.Add(new OrderDetailsProductResponse
            {
                ProductId=item.ProductId, 
                ImageUrl=item.Product.ImageURL,
                ProductType=item.ProductType.Name,
                Quantity=item.Quantity,
                Title=item.Product.Title,
                TotalPrice=item.TotalPrice
            }
            ));


            response.Data = orderDetailsResponse;
            return response;
        }

        public async Task<ServiceResponse<bool>> PlaceOrder(int userId)
        {
            var products = (await _cartService.GetDbCartProduct(userId)).Data;
            decimal totalPrice = 0;
            products.ForEach(pr => totalPrice += pr.Price * pr.Quantity);

            var orderItems = new List<OrderItem>();
            products.ForEach(pr => orderItems.Add(new OrderItem
            {
                ProductId = pr.ProductId,
                ProductTypeId = pr.ProductTypeId,
                Quantity = pr.Quantity,
                TotalPrice = pr.Price * pr.Quantity
            }));

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(_context.CartItems.Where(ci => ci.UserId == userId));

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
