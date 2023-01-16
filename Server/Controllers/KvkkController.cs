using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KvkkController : ControllerBase
    {
        private readonly IKvkkService _kvkkService;

        public KvkkController(IKvkkService kvkkService)
        {
            _kvkkService = kvkkService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Kvkk>>>> GetKvkk()
        {
            var result = await _kvkkService.GetKvkk();
            return Ok(result);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Kvkk>>>> GetAdminKvkk()
        {
            var result = await _kvkkService.GetAdminKvkk();
            return Ok(result);
        }



        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Kvkk>>>> AddKvkk(Kvkk brand)
        {
            var result = await _kvkkService.AddKvkk(brand);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Kvkk>>>> UpdateKvkk(Kvkk brand)
        {
            var result = await _kvkkService.UpdateKvkk(brand);
            return Ok(result);
        }

    }
}
