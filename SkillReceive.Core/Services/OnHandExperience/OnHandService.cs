using SkillReceive.Core.Contracts.OnHandExperience;
using SkillReceive.Core.Models.Skill.OnlineCourse;

namespace SkillReceive.Core.Services.OnHandExperience
{
    public class OnHandService : IOnHandService
    {
        public Task<IEnumerable<OnlineCategoryServiceModel>> AllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(OnlineFormModel model, int creatorId)
        {
            throw new NotImplementedException();
        }
    }
}
