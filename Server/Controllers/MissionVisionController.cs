using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionVisionController : ControllerBase
    {
        private readonly IMissionVisionService _missionVisionService;

        public MissionVisionController(IMissionVisionService missionVisionService)
        {
            _missionVisionService = missionVisionService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MissionVision>>>> GetMissionVision()
        {
            var result = await _missionVisionService.GetMissionVision();
            return Ok(result);
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<MissionVision>>>> GetAdminMissionVision()
        {
            var result = await _missionVisionService.GetAdminMissionVision();
            return Ok(result);
        }

        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<MissionVision>>>> AddMissionVision(MissionVision missionVision)
        {
            var result = await _missionVisionService.AddMissionVision(missionVision);
            return Ok(result);
        }

        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<MissionVision>>>> UpdateAbout(MissionVision missionVision)
        {
            var result = await _missionVisionService.UpdateMissionVision(missionVision);
            return Ok(result);
        }


    }
}
