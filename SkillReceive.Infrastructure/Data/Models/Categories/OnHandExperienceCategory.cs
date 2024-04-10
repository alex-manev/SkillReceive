using Microsoft.EntityFrameworkCore;
using SkillReceive.Infrastructure.Data.Models.Skills;
using System.ComponentModel.DataAnnotations;
using static SkillReceive.Infrastructure.Constants.DataConstants.OnHandExperiences.OnHandExperienceCategory;
namespace SkillReceive.Infrastructure.Data.Models.Categories
{
    public class OnHandExperienceCategory
    {
        [Key]
        [Comment("OnHandExperience category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Online course category name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<OnHandExperience> OnHandExperiences { get; set; } = new List<OnHandExperience>();
    }
}
