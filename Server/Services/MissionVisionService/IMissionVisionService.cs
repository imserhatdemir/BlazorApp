namespace BlazorApp.Server.Services.MissionVisionService
{
    public interface IMissionVisionService
    {
        Task<ServiceResponse<List<MissionVision>>> GetMissionVision();
    }
}
