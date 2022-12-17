using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactFormService _contactFormService;
        private readonly DataContext _context;

        public ContactController(IContactFormService contactFormService, DataContext context)
        {
            _contactFormService = contactFormService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ContactForm>>> CreateContact(ContactForm contact)
        {
            var result = await _contactFormService.CreateContact(contact);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ContactForm>>>> GetAllContacts()
        {
            var result = await _contactFormService.GetContacts();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteContact(int id)
        {
            var result = await _contactFormService.DeleteContact(id);
            return Ok(result);
        }

    }
}
