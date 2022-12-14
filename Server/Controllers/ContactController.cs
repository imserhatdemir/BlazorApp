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
        public async Task<ActionResult<ContactForm>> Contact(ContactForm contact)
        {
            var result = await _contactFormService.CreateContact(contact);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactForm>>> GetAllContacts()
        {
            var result = await _contactFormService.GetAllContacts();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<ContactForm>> DeleteContact(int id)
        {
            var result = await _contactFormService.DeleteContact(id);
            return Ok(result);
        }

    }
}
