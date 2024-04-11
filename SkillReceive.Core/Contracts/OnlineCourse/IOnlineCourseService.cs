using SkillReceive.Core.Models.Skill.OnlineCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillReceive.Core.Contracts.OnlineCourse
{
    public interface IOnlineCourseService
    {
        Task<IEnumerable<OnlineCategoryServiceModel>> AllCategories();
    }
}
