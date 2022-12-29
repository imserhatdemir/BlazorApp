﻿using BlazorApp.Shared;

namespace BlazorApp.Server.Services.SliderService
{
    public class SliderService : ISliderService
    {
        private readonly DataContext _context;

        public SliderService(DataContext context)
        {
            _context = context;
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
               .Where(c => !c.Deleted)
               .ToListAsync();
            return new ServiceResponse<List<Slider>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<Slider>>> GetSlide()
        {
            var categories = await _context.Sliders
              .Where(c => !c.Deleted && c.Visible)
              .ToListAsync();
            return new ServiceResponse<List<Slider>>
            {
                Data = categories
            };
        }

        public async Task<ServiceResponse<List<Slider>>> UpdateSlide(Slider slider)
        {
            var dbCategory = await GetSliderById(slider.Id);
            if (dbCategory == null)
            {
                return new ServiceResponse<List<Slider>>
                {
                    Success = false,
                    Message = "Category not found"
                };
            }

            dbCategory.Title = slider.Title;
            dbCategory.Url = slider.Url;
            dbCategory.Visible = slider.Visible;
            dbCategory.Description = slider.Description;
            dbCategory.Image = slider.Image;

            await _context.SaveChangesAsync();
            return await GetAdminSlide();
        }
    }
}
