namespace BlazorApp.Client.Services.ContactAddressService
{
    public interface IContactAddressService
    {
        List<ContactAddress> ContactAddresses { get; set; }
        Task GetContactAddress();
    }
}
