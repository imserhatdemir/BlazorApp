namespace BlazorApp.Client.Services.ContactAddressService
{
    public interface IContactAddressService
    {
        event Action OnChange;
        List<ContactAddress> ContactAddresses { get; set; }
        Task GetContactAddress();
    }
}
