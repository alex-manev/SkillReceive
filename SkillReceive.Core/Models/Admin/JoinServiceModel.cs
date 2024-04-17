using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Core.Models.Admin
{
    public class JoinServiceModel
    {
        public string SkillTitle { get; set; } = string.Empty;

        public string SkillImageURL { get; set; } = string.Empty;

        public string CreatorFullName { get; set; } = string.Empty;
        public string CreatorEmail { get; set; } = string.Empty;
    }
}
