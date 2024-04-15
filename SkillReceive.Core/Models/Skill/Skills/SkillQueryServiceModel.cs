namespace SkillReceive.Core.Models.Skill.Skills
{
    public class SkillQueryServiceModel
    {
        public int TotalSkillsCount { get; set; }

        public IEnumerable<SkillServiceModel> Skills { get; set; } = new List<SkillServiceModel>();


    }
}
