using SkillReceive.Core.Models.Skill.OnHandExperience;
using SkillReceive.Core.Models.Skill.OnlineCourse;

namespace SkillReceive.Core.Contracts.OnHandExperience
{
    public interface IOnHandService
    {
        Task<IEnumerable<OnHandCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(OnHandFormModel model, int creatorId);
    }
}
