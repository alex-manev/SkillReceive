using SkillReceive.Core.Models.Skill.OnHandExperience;
using SkillReceive.Core.Models.Skill.OnlineCourse;
using SkillReceive.Core.Models.Skill.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Core.Models.Admin
{
    public class MySkillsViewModel
    {
        public IEnumerable<SkillServiceModel> AddedSkills = new List<SkillServiceModel>();


        public IEnumerable<SkillServiceModel> JoinedOnHand = new List<SkillServiceModel>();

        public IEnumerable<SkillServiceModel> JoinedOnline = new List<SkillServiceModel>();

    }
}
