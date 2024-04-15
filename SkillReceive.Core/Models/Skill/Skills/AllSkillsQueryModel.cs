using SkillReceive.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Core.Models.Skill.Skills
{
    public class AllSkillsQueryModel
    {
        public int SkillsPerPage { get;} = 3;

        public string Category { get; set; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; } = null!;

        public SkillSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalSkillsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<SkillServiceModel> OnlineSkills { get; set; } = new List<SkillServiceModel>();
        public IEnumerable<SkillServiceModel> OnHandSkills { get; set; } = new List<SkillServiceModel>();


    }
}
