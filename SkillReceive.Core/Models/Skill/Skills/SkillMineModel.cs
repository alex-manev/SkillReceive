using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Core.Models.Skill.Skills
{
    public class SkillMineModel
    {
        public IEnumerable<SkillServiceModel> OnlineCourses { get; set; } = null!;

        public IEnumerable<SkillServiceModel> OnHandExperiences { get; set; } = null!;
    }
}
