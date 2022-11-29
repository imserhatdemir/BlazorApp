using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentreNumberController : ControllerBase
    {
        private readonly ICentreNumberService _centreNumberService;

        public CentreNumberController(ICentreNumberService centreNumberService)
        {
            _centreNumberService = centreNumberService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CentreNumber>>>> GetCentreNumber()
        {
            var result = await _centreNumberService.GetCentreNumber();
            return Ok(result);
        }
    }
}
