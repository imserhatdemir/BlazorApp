using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<BankAccount>>>> GetAdminBank()
        {
            var result = await _bankAccountService.GetAdminBankAccount();
            return Ok(result);
        }

        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<BankAccount>>>> DeleteBank(int id)
        {
            var result = await _bankAccountService.DeleteBank(id);
            return Ok(result);
        }


        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<BankAccount>>>> AddCategory(BankAccount category)
        {
            var result = await _bankAccountService.AddBank(category);
            return Ok(result);
        }


        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<BankAccount>>>> UpdateCategory(BankAccount category)
        {
            var result = await _bankAccountService.UpdateBank(category);
            return Ok(result);
        }


    }
}
