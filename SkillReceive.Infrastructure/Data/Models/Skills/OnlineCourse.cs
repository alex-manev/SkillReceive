using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillReceive.Infrastructure.Data.Models.Categories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SkillReceive.Infrastructure.Constants.DataConstants.OnlineCourses.OnlineCourse;

namespace SkillReceive.Infrastructure.Data.Models.Skills
{
    [Comment("Online Course")]
    public class OnlineCourse
    {
        [Key]
        [Comment("Online course identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Online course title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Online course description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(NeededTechnologiesMaxLength)]
        [Comment("Online course description")]
        public string NeededTechnologies { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Monthly price")]
        public decimal PricePerMonth { get; set; }

        [Required]
        [Comment("Online course image url")]
        public string ImageURL { get; set; } = string.Empty;

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Comment("Category")]
        public OnlineCourseCategory Category { get; set; } = null!;

        [Required]
        [Comment("Online course creator identifier")]
        public int CreatorId { get; set; } 

        [Required]
        [ForeignKey(nameof(CreatorId))]
        public Creator Creator { get; set; } = null!;
    }
}
