using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly IFaqService _faqService;

        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Faq>>>> GetFaq()
        {
            var result = await _faqService.GetFaq();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Faq>>> AddNewFaq(Faq faq)
        {
            var result = await _faqService.AddNewFaq(faq);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Faq>>> GetFaqById(int id)
        {
            var result = await _faqService.GetFaqById(id);
            return Ok(result);
        }


        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Faq>>>> GetAdminFaq()
        {
            var result = await _faqService.GetAdminFaq();
            return Ok(result);
        }


        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Faq>>>> DeleteFaq(int id)
        {
            var result = await _faqService.DeleteFaq(id);
            return Ok(result);
        }


        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Faq>>>> AddFaq(Faq faq)
        {
            var result = await _faqService.AddFaq(faq);
            return Ok(result);
        }


        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Faq>>>> UpdateFaq(Faq faq)
        {
            var result = await _faqService.UpdateFaq(faq);
            return Ok(result);
        }


        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Faq>>> CreateFaq(Faq product)
        {
            var result = await _faqService.CreateFaq(product);
            return Ok(result);
        }

    }
}
