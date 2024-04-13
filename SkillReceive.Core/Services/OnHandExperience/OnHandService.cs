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
    }
}
