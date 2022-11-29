using BlazorApp.Shared;

namespace BlazorApp.Client.Services.MissionVisionService
{
    public class MissionVisionService : IMissionVisionService
    {
        private readonly HttpClient _httpClient;

        public MissionVisionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<MissionVision> MissionVisions { get; set; } = new List<MissionVision>();

        public async Task GetMissionVision()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<MissionVision>>>("api/MissionVision");
            if (response != null && response.Data != null)
                MissionVisions = response.Data;
        }
    }
}
