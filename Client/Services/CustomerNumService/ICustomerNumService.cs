namespace BlazorApp.Client.Services.CustomerNumService
{
    public interface ICustomerNumService
    {
        event Action OnChange;
        List<CustomerNum> CustomerNums { get; set; }
        List<CustomerNum> AdminCustomerNums { get; set; }
        Task GetNumber();
        Task GetAdminNumber();
        Task DeleteNumber(int id);
        Task UpdateNumber(CustomerNum slider);
        Task AddNumber(CustomerNum slider);
        CustomerNum CreateNumber();
        Task<ServiceResponse<CustomerNum>> GetNumberId(int id);
        Task<CustomerNum> AddNewNumber(CustomerNum slide);
    }
}
