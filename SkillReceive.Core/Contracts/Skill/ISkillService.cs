using SkillReceive.Core.Enumerations;
using SkillReceive.Core.Models.Skill.OnHandExperience;
using SkillReceive.Core.Models.Skill.OnlineCourse;
using SkillReceive.Core.Models.Skill.Skills;

namespace SkillReceive.Core.Contracts.Skill
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillIndexServiceModel>> LastFourSkillsAsync();

        Task<SkillQueryServiceModel> AllOnlineAsync(string? category = null,
            string? searchTerm = null,
            SkillSorting sorting = SkillSorting.Newest ,
            int currPage = 1,
            int sikillsPerPage = 1 );

        Task<SkillQueryServiceModel> AllOnHandAsync(string? category = null,
            string? searchTerm = null,
            SkillSorting sorting = SkillSorting.Newest,
            int currPage = 1,
            int sikillsPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<IEnumerable<SkillServiceModel>> AllOnlineSkillsByCreatorIdAsync(int creatorId);

        Task<IEnumerable<SkillServiceModel>> AllOnHandSkillsByCreatorIdAsync(int creatorId);


        Task<IEnumerable<SkillServiceModel>> AllOnlineSkillsByUserId(string userId);

        Task<IEnumerable<SkillServiceModel>> AllOnHandSkillsByUserId(string userId);

        Task<bool> ExistsAsync(int id);

        Task<bool> ExistsOnlineAsync(int id);

        Task<bool> ExistsOnHandAsync(int id);

        Task<OnlineDetailServiceModel> OnlineDetailsByIdAsync(int id);

        Task<OnHandDetailsServiceModel> OnHandDetailsByIdAsync(int id);

        Task DeleteOnlineAsync(int skillId);

        Task DeleteOnHandAsync(int skillId);
    }
}
