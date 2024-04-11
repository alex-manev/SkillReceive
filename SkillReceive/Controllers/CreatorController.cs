using Microsoft.AspNetCore.Mvc;
using SkillReceive.Attributes;
using SkillReceive.Core.Contracts.Creator;
using SkillReceive.Core.Models.Creator;
using System.Security.Claims;
using static SkillReceive.Core.Constants.MessageConstants;

namespace SkillReceive.Controllers
{

    public class CreatorController : BaseController
    {
        private readonly ICreatorService creatorService;

        public CreatorController(ICreatorService _creatorService)
        {
            creatorService = _creatorService; 
        }

        [HttpGet]
        [NotACreator]
        public IActionResult Become()
        {
            var model = new BecomeCreatorFormModel();
            return View(model);
        }

        [HttpPost]
        [NotACreator]
        public async Task<IActionResult> Become(BecomeCreatorFormModel model)
        {
            if (await creatorService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }

            if (await creatorService.UserHasSkillsAsync(User.Id()))
            {
                ModelState.AddModelError("Error", HasSkills);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await creatorService.CreateAsync(User.Id(), model.PhoneNumber);


           return RedirectToAction(nameof(OnlineCourseController.All), "Skill");
        }

    }
}
