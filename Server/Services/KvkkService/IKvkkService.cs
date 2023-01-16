namespace BlazorApp.Server.Services.KvkkService
{
    public interface IKvkkService
    {
        Task<ServiceResponse<List<Kvkk>>> GetKvkk();
        Task<ServiceResponse<List<Kvkk>>> GetAdminKvkk();
        Task<ServiceResponse<List<Kvkk>>> AddKvkk(Kvkk brand);
        Task<ServiceResponse<List<Kvkk>>> UpdateKvkk(Kvkk brand);
    }
}
