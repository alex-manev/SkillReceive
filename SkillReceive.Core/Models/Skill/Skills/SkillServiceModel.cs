using System.ComponentModel.DataAnnotations;
using static SkillReceive.Core.Constants.MessageConstants;
using static SkillReceive.Infrastructure.Constants.DataConstants.OnlineCourses.OnlineCourse;

namespace SkillReceive.Core.Models.Skill.Skills
{
    public class SkillServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageURL { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            "0.00",
            PricePerMonthMaximum,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Price per month must be a positive number and less than {2}lv.")]
        [Display(Name = "Price Per Month")]
        public decimal PriePerMonth { get; set; }
    }
}