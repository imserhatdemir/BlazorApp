using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Responsibility>>>> GetAdminResp()
        {
            var result = await _responsibilityService.GetAdminResp();
            return Ok(result);
        }

        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Responsibility>>>> AddResp(Responsibility responsibility)
        {
            var result = await _responsibilityService.AddResp(responsibility);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Responsibility>>>> UpdateAbout(Responsibility responsibility)
        {
            var result = await _responsibilityService.UpdateResp(responsibility);
            return Ok(result);
        }
    }
}
