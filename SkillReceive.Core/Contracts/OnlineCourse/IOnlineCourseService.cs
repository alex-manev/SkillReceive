using SkillReceive.Core.Models.Skill.OnlineCourse;
using SkillReceive.Core.Models.Skill.Skills;

namespace SkillReceive.Core.Contracts.OnlineCourse
{
    public interface IOnlineCourseService
    {
        Task<IEnumerable<OnlineCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(OnlineFormModel model, int creatorId);

        Task EditAsync(int skillId, OnlineFormModel model);

        Task<bool> HasCreatorWithIdAsync(int onlineCourseId, string userId);

        Task<OnlineFormModel?> GetOnlineFormModelByIdAsync(int id);
    }
}
