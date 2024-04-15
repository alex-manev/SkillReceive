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

        Task<IEnumerable<SkillServiceModel>> AllSkillsByCreatorIdAsync(int creatorId);

        Task<IEnumerable<SkillServiceModel>> AllSkillsByUserId(string userId);

        Task<bool> ExistsAsync(int id);

        Task<OnlineDetailServiceModel> OnlineDetailsByIdAsync(int id);

        Task<OnHandDetailsServiceModel> OnHandDetailsByIdAsync(int id);
    }
}
