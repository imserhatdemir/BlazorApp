namespace BlazorApp.Client.Services.ContactAddressService
{
    public interface IContactAddressService
    {
        event Action OnChange;
        List<ContactAddress> ContactAddresses { get; set; }
        List<ContactAddress> AdminContactAddresses { get; set; }
        Task GetContactAddress();
        Task GetAdminContactAddress();
        Task DeleteAddress(int id);
        Task UpdateAddress(ContactAddress slider);
        Task AddAddress(ContactAddress slider);
        ContactAddress CreateAddress();
        Task<ServiceResponse<ContactAddress>> GetAddressID(int id);
        Task<ContactAddress> AddNewAddress(ContactAddress slide);
    }
}
