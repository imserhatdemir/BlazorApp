using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly ISendMailService _send;

        public SendMailController(ISendMailService send)
        {
            _send = send;
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<SendMail>>> CreateMail(SendMail send)
        {
            var result = await _send.AddMail(send);
            return Ok(result);
        }

        [HttpGet("admin"),Authorize(Roles ="Admin")]
        public async Task<ActionResult<ServiceResponse<List<SendMail>>>> GetMails()
        {
            var result = await _send.GetMail();
            return Ok(result);
        }

        [HttpDelete("admin") , Authorize(Roles ="Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteMail(int id)
        {
            var result = await _send.DeleteMail(id);
            return Ok(result);
        }
    }
}
