using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Contracts.OnlineCourse;
using SkillReceive.Core.Models.Skill.OnlineCourse;
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
    }
}
