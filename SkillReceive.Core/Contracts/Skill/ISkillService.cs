using SkillReceive.Core.Enumerations;
using SkillReceive.Core.Models.Skill.Skills;

namespace SkillReceive.Core.Contracts.Skill
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillIndexServiceModel>> LastFourSkillsAsync();

        Task<SkillQueryServiceModel> AllOnlineAsync(string? category = null,
            string? searchTerm = null,
            SkillSorting sorting = SkillSorting.Level ,
            int currPage = 1,
            int sikillsPerPage = 1 );

        Task<SkillQueryServiceModel> AllOnHandAsync(string? category = null,
            string? searchTerm = null,
            SkillSorting sorting = SkillSorting.Level,
            int currPage = 1,
            int sikillsPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();
    }
}
