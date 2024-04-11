using SkillReceive.Core.Models.Skill.Skills;

namespace SkillReceive.Core.Contracts.Skill
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillIndexServiceModel>> LastTenSkills();
    }
}
