using SkillReceive.Core.Models.Skill.OnlineCourse;

namespace SkillReceive.Core.Contracts.OnHandExperience
{
    public interface IOnHandService
    {
        Task<IEnumerable<OnlineCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(OnlineFormModel model, int creatorId);
    }
}
