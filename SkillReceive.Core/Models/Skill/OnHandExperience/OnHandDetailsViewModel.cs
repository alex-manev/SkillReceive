using SkillReceive.Core.Contracts;

namespace SkillReceive.Core.Models.Skill.OnHandExperience
{
    public class OnHandDetailsViewModel : ISkillModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string Requirements { get; set; } = string.Empty;

        public string ImageURL { get; set; } = string.Empty;
    }
}
