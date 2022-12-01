namespace BlazorApp.Client.Services.CustomerNumService
{
    public interface ICustomerNumService
    {
        event Action OnChange;
        List<CustomerNum> CustomerNums { get; set; }
        Task GetNumber();
    }
}
