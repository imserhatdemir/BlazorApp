namespace BlazorApp.Server.Services.ContactAddressService
{
    public interface IContactAddressService
    {
        Task<ServiceResponse<List<ContactAddress>>> GetContactAddress();
    }
}
