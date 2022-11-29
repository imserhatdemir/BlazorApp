namespace BlazorApp.Client.Services.CustomerNumService
{
    public interface ICustomerNumService
    {
        List<CustomerNum> CustomerNums { get; set; }
        Task GetNumber();
    }
}
