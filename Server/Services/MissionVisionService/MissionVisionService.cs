namespace BlazorApp.Server.Services.MissionVisionService
{
    public class MissionVisionService : IMissionVisionService   
    {
        private readonly DataContext _context;

        public MissionVisionService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MissionVision>>> GetMissionVision()
        {
            var about = await _context.MissionVisions.ToListAsync();
            return new ServiceResponse<List<MissionVision>>
            {
                Data = about
            };
        }
    }
}
