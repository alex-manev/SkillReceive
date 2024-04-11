using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Core.Models.Skill.OnlineCourse;
using SkillReceive.Core.Models.Skill.Skills;

namespace SkillReceive.Controllers
{
    public class SkillController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult All()
        {
            var model = new AllSkillsQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new AllSkillsQueryModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SkillFormModel model)
        {
            return RedirectToAction(nameof(All));
        }
    }
}
