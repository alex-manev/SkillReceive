using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillReceive.Infrastructure.Data.Models.Categories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SkillReceive.Infrastructure.Constants.DataConstants.OnHandExperiences.OnHandExperience;

namespace SkillReceive.Infrastructure.Data.Models.Skills
{
    [Comment("On Hand Experience")]
    public class OnHandExperience
    {
        [Key]
        [Comment("On Hand Experience identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("On Hand Experience title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("On Hand Experience description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(LocationMaxLength)]
        [Comment("On Hand Experience location")]
        public string Location { get; set; } = string.Empty;

        [Required]
        [MaxLength(RequirementsMaxLength)]
        [Comment("On Hand Experience location")]
        public string Requirements { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Monthly price")]
        public decimal PricePerMonth { get; set; }

        [Required]
        [Comment("On Hand Experience image url")]
        public string ImageURL { get; set; } = string.Empty;

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }


        [ForeignKey(nameof(CategoryId))]
        [Comment("Category")]
        public OnHandExperienceCategory Category { get; set; } = null!;

        [Required]
        [Comment("On Hand Experience creator identifier")]
        public int CreatorId { get; set; } 

        [Required]
        [ForeignKey(nameof(CreatorId))]
        public Creator Creator { get; set; } = null!;

        [Comment("At Hand Experience participants")]
        public IList<ApplicationUser> Participants { get; set; } = new List<ApplicationUser>();
    }
}
