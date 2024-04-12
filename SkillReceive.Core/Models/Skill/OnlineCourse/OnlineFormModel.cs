using System.ComponentModel.DataAnnotations;
using static SkillReceive.Core.Constants.MessageConstants;
using static SkillReceive.Infrastructure.Constants.DataConstants.OnlineCourses.OnlineCourse;

namespace SkillReceive.Core.Models.Skill.OnlineCourse
{
    public class OnlineFormModel
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
        [StringLength(NeededTechnologiesMaxLength,
            MinimumLength = NeededTechnologiesMinLength,
            ErrorMessage = LengthMessage)]
        public string NeededTechnologies { get; set; } = null!;

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

        public IEnumerable<OnlineCategoryServiceModel> Categories { get; set; } = new List<OnlineCategoryServiceModel>();
    }
}
