using SkillReceive.Core.Models.Creator;
using SkillReceive.Core.Models.Skill.Skills;

namespace SkillReceive.Core.Models.Skill.OnlineCourse
{
    public class OnlineDetailServiceModel : SkillServiceModel
    {
        public string Description { get; set; } = null!;

        public string NeededTechnologies { get; set; } = null!;
        public string Category { get; set; } = null!;

        public CreatorServiceModel Creator { get; set; } = null!;
    }
}
