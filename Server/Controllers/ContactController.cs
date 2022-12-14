using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactFormService _contactFormService;

        public ContactController(IContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<ContactForm>>> GetContact()
        {
            var result = await _contactFormService.GetContact();
            return Ok(result);
        }



        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ContactForm>>> AddContact(ContactForm contact)
        {
            var result = await _contactFormService.AddContact(contact);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<ContactForm>>> DeleteContact(int id) 
        {
            var result = await _contactFormService.DeleteContact(id);
            return Ok(result);
        }
    }
}
