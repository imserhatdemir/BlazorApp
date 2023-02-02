using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerNumController : ControllerBase
    {
        private readonly ICustomerNumService _customerNumService;

        public CustomerNumController(ICustomerNumService customerNumService)
        {
            _customerNumService = customerNumService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CustomerNum>>>> GetNumber()
        {
            var result = await _customerNumService.GetNumber();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CustomerNum>>> GetNumber(int id)
        {
            var result = await _customerNumService.GetNumber(id);
            return Ok(result);
        }


        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<CustomerNum>>>> GetAdminNumber()
        {
            var result = await _customerNumService.GetAdminNumber();
            return Ok(result);
        }


        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<CustomerNum>>>> DeleteNumber(int id)
        {
            var result = await _customerNumService.DeleteNumber(id);
            return Ok(result);
        }


        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<CustomerNum>>>> AddAddress(CustomerNum slider)
        {
            var result = await _customerNumService.AddNumber(slider);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<CustomerNum>>>> UpdateNumber(CustomerNum slider)
        {
            var result = await _customerNumService.UpdateNumber(slider);
            return Ok(result);
        }

    }
}
