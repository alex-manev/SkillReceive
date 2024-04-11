using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Core.Contracts.Creator;
using SkillReceive.Core.Models.Creator;
using SkillReceive.Extensions;

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
        public async Task<IActionResult> Become()
        {
            if (await creatorService.ExistsByIdAsync(User.Id()))
            {
                return BadRequest();
            }


            var model = new BecomeCreatorFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeCreatorFormModel model)
        {
           return RedirectToAction(nameof(OnlineCourseController.All), "Skill");
        }

    }
}
