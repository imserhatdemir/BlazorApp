namespace BlazorApp.Client.Services.KvkkService
{
    public interface IKvkkService
    {
        event Action OnChange;
        List<Kvkk> KvkkMain { get; set; }
        List<Kvkk> AdminKvkk { get; set; }
        Task GetKvkk();
        Task GetAdminKvkk();
        Task UpdateKvkk(Kvkk brand);
        Task AddKvkk(Kvkk brand);
        Kvkk CreateKvkk();
    }
}
