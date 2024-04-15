using SkillReceive.Core.Models.Creator;
using SkillReceive.Core.Models.Skill.Skills;

namespace SkillReceive.Core.Models.Skill.OnHandExperience
{
    public class OnHandDetailsServiceModel : SkillServiceModel
    {
        public string Description { get; set; } = null!;

        public string Requirements { get; set; } = null!;

        public string Location { get; set; } = null!;
        public string Category { get; set; } = null!;

        public CreatorServiceModel Creator { get; set; } = null!;
    }
}
