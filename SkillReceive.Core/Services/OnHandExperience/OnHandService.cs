using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts.OnHandExperience;
using SkillReceive.Core.Models.Skill.OnHandExperience;
using SkillReceive.Core.Models.Skill.OnlineCourse;
using SkillReceive.Infrastructure.Data.Common;
using SkillReceive.Infrastructure.Data.Models.Categories;

namespace SkillReceive.Core.Services.OnHandExperience
{
    public class OnHandService : IOnHandService
    {
        private readonly IRepository repository;

        public OnHandService(IRepository _repository)
        {
                repository = _repository;
        }

        public async Task<IEnumerable<OnHandCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<OnHandExperienceCategory>()
                .Select(c => new OnHandCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<OnHandExperienceCategory>()
               .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(OnHandFormModel model, int creatorId)
        {
            Infrastructure.Data.Models.Skills.OnHandExperience onHandExperience = new Infrastructure.Data.Models.Skills.OnHandExperience()
            {
                Title = model.Title,
                CreatorId = creatorId,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Requirements = model.Requirements,
                Location = model.Location,
                PricePerMonth = model.PricePerMonth,
                ImageURL = model.ImageURL
            };

            await repository.AddAsync(onHandExperience);
            await repository.SaveChangesAsync();

            return onHandExperience.Id;

        }

        public async Task EditAsync(int skillId, OnHandFormModel model)
        {
            var skill = await repository.GetByIdAsync<Infrastructure.Data.Models.Skills.OnHandExperience>(skillId);

            if (skill != null)
            {
                skill.CategoryId = model.CategoryId;
                skill.Location = model.Location;
                skill.Requirements = model.Requirements;
                skill.PricePerMonth = model.PricePerMonth;
                skill.Description = model.Description;
                skill.ImageURL = model.ImageURL;
                skill.Title = model.Title;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<OnHandFormModel?> GetOnHandFormModelByIdAsync(int id)
        {
            var onHandExp = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                .Where(s => s.IsApproved)
                .Where(o => o.Id == id)
                .Select(o => new OnHandFormModel()
                {
                    Location = o.Location,
                    Requirements = o.Requirements,
                    CategoryId = o.CategoryId,
                    Description = o.Description,
                    PricePerMonth = o.PricePerMonth,
                    ImageURL = o.ImageURL,
                    Title = o.Title
                })
                .FirstOrDefaultAsync();

            if (onHandExp != null)
            {
                onHandExp.Categories = await AllCategoriesAsync();
            }

            return onHandExp;
        }

        public async Task<bool> HasCreatorWithIdAsync(int onHandExpId, string userId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnHandExperience>()
                 .AnyAsync(o => o.Id == onHandExpId && o.Creator.UserId == userId);
        }
    }
}
