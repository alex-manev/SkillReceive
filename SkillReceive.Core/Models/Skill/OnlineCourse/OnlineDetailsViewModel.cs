using SkillReceive.Core.Contracts;

namespace SkillReceive.Core.Models.Skill.OnlineCourse
{
    public class OnlineDetailsViewModel : ISkillModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string NeededTechnologies { get; set; } = string.Empty;

        public string ImageURL { get; set; } = string.Empty;
    }
}
