using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BankAccount>>>> GetBankAccount()
        {
            var result = await _bankAccountService.GetBankAccount();
            return Ok(result);
        }
    }
}
