using BlazorApp.Client.Pages;
using BlazorApp.Shared;
using Stripe;

namespace BlazorApp.Server.Services.SliderService
{
    public class SliderService : ISliderService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SliderService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        private async Task<Slider> GetSliderById(int id)
        {
            return await _context.Sliders.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ServiceResponse<List<Slider>>> AddSlide(Slider slider)
        {
            slider.Editing = slider.IsNew = false;
            _context.Sliders.Add(slider);
            await _context.SaveChangesAsync();
            return await GetAdminSlide();
        }

        public async Task<ServiceResponse<List<Slider>>> DeleteSlide(int id)
        {
            Slider category = await GetSliderById(id);
            if (category == null)
            {
                return new ServiceResponse<List<Slider>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }
            _context.Sliders.Remove(category);
            await _context.SaveChangesAsync();

            return await GetAdminSlide();
        }

        public async Task<ServiceResponse<List<Slider>>> GetAdminSlide()
        {
            var categories = await _context.Sliders
               .Where(c => !c.Deleted).Include(c => c.Images)
               .ToListAsync();
            return new ServiceResponse<List<Slider>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<Slider>>> GetSlide()
        {
            var categories = await _context.Sliders
              .Where(c => !c.Deleted && c.Visible).Include(c => c.Images)
              .ToListAsync();
            return new ServiceResponse<List<Slider>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<Slider>>> UpdateSlide(Slider slider)
        {
            var dbCategory = await _context.Sliders
               .Include(p => p.Images)
               .FirstOrDefaultAsync(p => p.Id == slider.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Slider>>
                {
                    Success = false,
                    Message = "About not found"
                };
            }
            dbCategory.Title = slider.Title;
            dbCategory.Image = slider.Image;
            dbCategory.Description = slider.Description;
            dbCategory.Visible = slider.Visible;
            dbCategory.DataSlide = slider.DataSlide;
            dbCategory.Active = slider.Active;

            var productImages = dbCategory.Images;
            _context.SliderImages.RemoveRange(productImages);

            dbCategory.Images = slider.Images;

            await _context.SaveChangesAsync();
            return await GetAdminSlide();
        }

        public async Task<ServiceResponse<Slider>> GetSlider(int id)
        {
            var response = new ServiceResponse<Slider>();
            Slider product = null;
            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Sliders.Include(c => c.Images)
                    .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            else
            {
                product = await _context.Sliders.Include(c => c.Images)
                     .FirstOrDefaultAsync(p => p.Id == id && !p.Deleted);

            }
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this product does not exist.";
            }
            else
            {
                response.Data = product;
            }
            return response;
        }

        public async Task<ServiceResponse<Slider>> AddSliderNew(Slider slider)
        {
            _context.Sliders.Add(slider);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Slider> { Data = slider };
        }
    }
}
