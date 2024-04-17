using Microsoft.AspNetCore.Identity;
using SkillReceive.Infrastructure.Data.Models.Skills;
using System.ComponentModel.DataAnnotations;
using static SkillReceive.Infrastructure.Constants.DataConstants.User;

namespace SkillReceive.Infrastructure.Data.Models
{
    public class ApplicationUser :  IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;


        public List<OnHandExperience> OnHandExperiences { get; set; } = new List<OnHandExperience>();

        public List<OnlineCourse> OnlineCourses { get; set; } = new List<OnlineCourse>();

        public Creator? Creator { get; set; }
    }
}
