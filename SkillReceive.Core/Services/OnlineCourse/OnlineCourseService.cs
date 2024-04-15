using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts.OnlineCourse;
using SkillReceive.Core.Models.Skill.OnlineCourse;
using SkillReceive.Core.Models.Skill.Skills;
using SkillReceive.Infrastructure.Data.Common;
using SkillReceive.Infrastructure.Data.Models.Categories;

namespace SkillReceive.Core.Services.OnlineCourse
{
    public class OnlineCourseService : IOnlineCourseService
    {
        private readonly IRepository repository;

        public OnlineCourseService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<OnlineCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<OnlineCourseCategory>()
                .Select(c => new OnlineCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task EditAsync(int skillId, OnlineFormModel model)
        {
            var skill = await repository.GetByIdAsync<Infrastructure.Data.Models.Skills.OnlineCourse>(skillId);

            if (skill != null)
            {
                skill.CategoryId = model.CategoryId;
                skill.NeededTechnologies = model.NeededTechnologies;
                skill.PricePerMonth = model.PricePerMonth;
                skill.Description = model.Description;
                skill.ImageURL = model.ImageURL;
                skill.Title = model.Title;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<OnlineCourseCategory>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(OnlineFormModel model, int creatorId)
        {
            Infrastructure.Data.Models.Skills.OnlineCourse onlineCourse = new Infrastructure.Data.Models.Skills.OnlineCourse()
            {
                Title = model.Title,
                CreatorId = creatorId,
                CategoryId = model.CategoryId,
                Description = model.Description,
                NeededTechnologies = model.NeededTechnologies,
                PricePerMonth = model.PricePerMonth,
                ImageURL = model.ImageURL
            };

            await repository.AddAsync(onlineCourse);
            await repository.SaveChangesAsync();

            return onlineCourse.Id;

        }

        public async Task<bool> HasCreatorWithIdAsync(int onlineCourseId, string userId)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .AnyAsync(o => o.Id == onlineCourseId && o.Creator.UserId == userId);
        }

        public async Task<OnlineFormModel?> GetOnlineFormModelByIdAsync(int id)
        {
            var onlineCourse = await repository.AllReadOnly<Infrastructure.Data.Models.Skills.OnlineCourse>()
                .Where(o => o.Id == id)
                .Select(o => new OnlineFormModel()
                {
                    NeededTechnologies = o.NeededTechnologies,
                    CategoryId = o.CategoryId,
                    Description = o.Description,
                    PricePerMonth = o.PricePerMonth,
                    ImageURL = o.ImageURL,
                    Title = o.Title
                })
                .FirstOrDefaultAsync();

            if (onlineCourse != null)
            {
                onlineCourse.Categories = await AllCategoriesAsync();
            }

            return onlineCourse;
        }
    }
}
