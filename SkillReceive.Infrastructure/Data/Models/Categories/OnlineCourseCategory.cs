using Microsoft.EntityFrameworkCore;
using SkillReceive.Infrastructure.Data.Models.Skills;
using System.ComponentModel.DataAnnotations;
using static SkillReceive.Infrastructure.Constants.DataConstants.OnlineCourses.OnlineCourseCategory;
namespace SkillReceive.Infrastructure.Data.Models.Categories
{
    [Comment("Online course category")]
    public class OnlineCourseCategory
    {
        [Key]
        [Comment("Online course category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Online course category name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<OnlineCourse> OnlineCourses { get; set; } = new List<OnlineCourse>();
    }
}
