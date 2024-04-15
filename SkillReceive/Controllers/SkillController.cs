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
        public async Task<IActionResult> All([FromQuery] AllSkillsQueryModel query)
        {
            var onlinemodel = await skillService.AllOnlineAsync(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.SkillsPerPage
                );

            var onHandModel = await skillService.AllOnHandAsync(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.SkillsPerPage
                );

            query.TotalSkillsCount = onlinemodel.TotalSkillsCount + onHandModel.TotalSkillsCount;
            query.OnlineSkills = onlinemodel.Skills;
            query.OnHandSkills = onHandModel.Skills;
            query.Categories = await skillService.AllCategoriesNamesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();

            SkillMineModel model;

            if (await creatorService.ExistsByIdAsync(userId))
            {
                int creatorId = await creatorService.GetCreatorIdAsync(userId) ?? 0;
                model = new SkillMineModel()
                {
                    OnlineCourses = await skillService.AllOnlineSkillsByCreatorIdAsync(creatorId),
                    OnHandExperiences = await skillService.AllOnHandSkillsByCreatorIdAsync(creatorId)
                };
            }
            else
            {
                model = new SkillMineModel() 
                {
                    OnlineCourses = await skillService.AllOnlineSkillsByUserId(userId),
                    OnHandExperiences = await skillService.AllOnHandSkillsByUserId(userId)
                };
            }

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
