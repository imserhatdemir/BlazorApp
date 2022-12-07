using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OrderOverviewResponse>>>> GetOrders()
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<ServiceResponse<OrderDetailsResponse>>> GetOrderDetails(int orderId)
        {
            var result = await _orderService.GetOrdersDetails(orderId);
            return Ok(result);
        }


        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<OrderOverviewResponse>>>> GetAdminOrders()
        {
            var result = await _orderService.GetAdminOrders();
            return Ok(result);
        }

        [HttpGet("{orderId}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<OrderDetailsResponse>>> GetAdminOrderDetails(int orderId)
        {
            var result = await _orderService.GetAdminOrdersDetails(orderId);
            return Ok(result);
        }



    }
}
