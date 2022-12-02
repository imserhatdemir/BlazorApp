namespace BlazorApp.Server.Services.MissionVisionService
{
    public interface IMissionVisionService
    {
        Task<ServiceResponse<List<MissionVision>>> GetMissionVision();
        Task<ServiceResponse<List<MissionVision>>> GetAdminMissionVision();
        Task<ServiceResponse<List<MissionVision>>> AddMissionVision(MissionVision missionVision);
        Task<ServiceResponse<List<MissionVision>>> UpdateMissionVision(MissionVision missionVision);
    }
}
