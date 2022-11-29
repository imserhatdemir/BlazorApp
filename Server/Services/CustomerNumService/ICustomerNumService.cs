namespace BlazorApp.Server.Services.CustomerNumService
{
    public interface ICustomerNumService
    {
        Task<ServiceResponse<List<CustomerNum>>> GetNumber();
    }
}
