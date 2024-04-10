using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Core.Models.Creator;

namespace SkillReceive.Controllers
{
    [Authorize]
    public class CreatorController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            var model = new BecomeCreatorFormModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeCreatorFormModel model)
        {
           return RedirectToAction(nameof(SkillController.All), "Skill");
        }

    }
}
