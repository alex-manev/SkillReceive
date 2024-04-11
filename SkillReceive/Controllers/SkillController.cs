using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Core.Contracts.Creator;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Models.Skill.OnlineCourse;
using SkillReceive.Core.Models.Skill.Skills;
using System.Security.Claims;

namespace SkillReceive.Controllers
{
    public class SkillController : BaseController
    {
        private readonly ISkillService skillService;
        private readonly ICreatorService creatorService;

        public SkillController(ISkillService _skillService, ICreatorService _creatorService)
        {
            skillService = _skillService;
            creatorService = _creatorService;
        }

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
        public async Task<IActionResult> Add()
        {
            if (await creatorService.ExistsByIdAsync(User.Id()))
            {
                return View();
            }

            return RedirectToAction(nameof(CreatorController.Become), "Creator");

        }


    }
}
