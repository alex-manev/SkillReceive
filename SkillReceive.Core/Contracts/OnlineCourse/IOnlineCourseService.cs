using SkillReceive.Core.Models.Skill.OnlineCourse;

namespace SkillReceive.Core.Contracts.OnlineCourse
{
    public interface IOnlineCourseService
    {
        Task<IEnumerable<OnlineCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(OnlineFormModel model, int creatorId);
    }
}
