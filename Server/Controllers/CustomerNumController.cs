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


        
    }
}
