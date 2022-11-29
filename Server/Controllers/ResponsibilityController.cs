using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibilityController : ControllerBase
    {
        private readonly IResponsibilityService _responsibilityService;

        public ResponsibilityController(IResponsibilityService responsibilityService)
        {
            _responsibilityService = responsibilityService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Responsibility>>>> GetResponsibility()
        {
            var result = await _responsibilityService.GetResponsibility();
            return Ok(result);
        }
    }
}
