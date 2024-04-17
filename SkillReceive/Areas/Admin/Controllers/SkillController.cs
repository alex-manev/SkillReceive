using Microsoft.AspNetCore.Mvc;
using SkillReceive.Core.Contracts.Creator;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Models.Admin;
using System.Security.Claims;

namespace SkillReceive.Areas.Admin.Controllers
{
    public class SkillController : AdminBaseController
    {
        private readonly ISkillService skillService;

        private readonly ICreatorService creatorService;

        public SkillController(ISkillService _skillService, ICreatorService _creatorService)
        {
            skillService = _skillService;
            creatorService = _creatorService;
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            var creatorId = await creatorService.GetCreatorIdAsync(userId) ?? 0;


            var mySkills = new MySkillsViewModel()
            {
                AddedSkills = await skillService.AllOnlineSkillsByCreatorIdAsync(creatorId),
                JoinedOnline = await skillService.AllOnlineSkillsByUserId(userId),
                JoinedOnHand = await skillService.AllOnHandSkillsByUserId(userId)
            };

            return View(mySkills);
        }

        [HttpGet]
        public async Task<IActionResult> Approve() 
        {
            var model = await skillService.GetUnApprovedAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int skillId) 
        {
            await skillService.ApproveSkillAsync(skillId);

            return RedirectToAction(nameof(Approve));
        }
    }
}
