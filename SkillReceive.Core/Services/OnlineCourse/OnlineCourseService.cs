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

        public async Task<IEnumerable<OnlineCategoryServiceModel>> AllCategories()
        {
            return await repository.AllReadOnly<OnlineCourseCategory>()
                .Select(c => new OnlineCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
