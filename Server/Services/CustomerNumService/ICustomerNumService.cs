namespace BlazorApp.Server.Services.CustomerNumService
{
    public interface ICustomerNumService
    {
        Task<ServiceResponse<List<CustomerNum>>> GetNumber();
        Task<ServiceResponse<List<CustomerNum>>> GetAdminNumber();
        Task<ServiceResponse<List<CustomerNum>>> AddNumber(CustomerNum slider);
        Task<ServiceResponse<List<CustomerNum>>> UpdateNumber(CustomerNum slider);
        Task<ServiceResponse<List<CustomerNum>>> DeleteNumber(int id);
        Task<ServiceResponse<CustomerNum>> GetNumber(int id);
    }
}
