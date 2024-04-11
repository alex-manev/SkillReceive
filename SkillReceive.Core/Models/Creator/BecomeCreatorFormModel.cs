using System.ComponentModel.DataAnnotations;
using static SkillReceive.Core.Constants.MessageConstants;
using static SkillReceive.Infrastructure.Constants.DataConstants.Creator;

namespace SkillReceive.Core.Models.Creator
{
    public class BecomeCreatorFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CreatorPhoneNumberMaxLength,
            MinimumLength = CreatorPhoneNumberMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
