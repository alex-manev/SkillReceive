using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillReceive.Infrastructure.Data.Models.Skills;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SkillReceive.Infrastructure.Constants.DataConstants;
using static SkillReceive.Infrastructure.Constants.DataConstants.Creator;

namespace SkillReceive.Infrastructure.Data.Models
{
    public class Creator
    {
        [Key]
        [Comment("Creator identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CreatorPhoneNumberMaxLength)]
        [Comment("Creator phone number")]
        public string PhoneNumber { get; set; } = string.Empty;


        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [Comment("User")]
        public IdentityUser User { get; set; } = null!;

        public List<OnHandExperience> OnHandExperiences { get; set; } = new List<OnHandExperience>();

        public List<OnlineCourse> OnlineCourses { get; set; } = new List<OnlineCourse>();
    }
}
