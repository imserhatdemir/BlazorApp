namespace BlazorApp.Server.Services.ContactAddressService
{
    public interface IContactAddressService
    {
        Task<ServiceResponse<List<ContactAddress>>> GetContactAddress(); 
        Task<ServiceResponse<List<ContactAddress>>> GetAdminAddress();
        Task<ServiceResponse<List<ContactAddress>>> AddAddress(ContactAddress slider);
        Task<ServiceResponse<List<ContactAddress>>> UpdateAddress(ContactAddress slider);
        Task<ServiceResponse<List<ContactAddress>>> DeleteAddress(int id);
        Task<ServiceResponse<ContactAddress>> GetAddress(int id);
    }
}
