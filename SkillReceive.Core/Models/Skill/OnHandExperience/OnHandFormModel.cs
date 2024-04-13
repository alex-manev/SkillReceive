using Microsoft.EntityFrameworkCore;
using SkillReceive.Core.Models.Skill.OnlineCourse;
using System.ComponentModel.DataAnnotations;
using static SkillReceive.Core.Constants.MessageConstants;
using static SkillReceive.Infrastructure.Constants.DataConstants.OnHandExperiences.OnHandExperience;

namespace SkillReceive.Core.Models.Skill.OnHandExperience
{
    public class OnHandFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = LengthMessage)]

        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength,
            MinimumLength = DescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(LocationMaxLength,
            MinimumLength = LocationMinLength,
            ErrorMessage = LengthMessage)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [StringLength(RequirementsMaxLength,
            MinimumLength = RequirementsMinLength,
            ErrorMessage = LengthMessage)]
        public string Requirements { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            "0.00",
            PricePerMonthMaximum,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Price per month must be a positive number and less than {2}lv.")]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }


        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageURL { get; set; } = null!;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<OnHandCategoryServiceModel> Categories { get; set; } = new List<OnHandCategoryServiceModel>();
    }
}
