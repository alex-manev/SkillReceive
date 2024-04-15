using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Attributes;
using SkillReceive.Core.Contracts.Creator;
using SkillReceive.Core.Contracts.OnHandExperience;
using SkillReceive.Core.Contracts.OnlineCourse;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Models.Skill.OnHandExperience;
using SkillReceive.Core.Models.Skill.OnlineCourse;
using SkillReceive.Core.Services.OnlineCourse;
using System.Security.Claims;

namespace SkillReceive.Controllers
{

    public class OnHandExperienceController : BaseController
    {
        private readonly ICreatorService creatorService;
        private readonly IOnHandService onHandService;
        private readonly ISkillService skillService;

        public OnHandExperienceController(ICreatorService _creatorService, IOnHandService _onHandService, ISkillService _skillService)
        {                                 
            creatorService = _creatorService;
            onHandService = _onHandService;
            skillService = _skillService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllOnHandQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new AllOnHandQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await skillService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await skillService.OnHandDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [MustBeCreator]
        public async Task<IActionResult> Add()
        {
            var model = new OnHandFormModel()
            {
                Categories = await onHandService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeCreator]
        public async Task<IActionResult> Add(OnHandFormModel model)
        {
            if (await onHandService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await onHandService.AllCategoriesAsync();

                return View(model);
            }

            int? creatorId = await creatorService.GetCreatorIdAsync(User.Id());

            int newOnHandExperienceId = await onHandService.CreateAsync(model, creatorId ?? 0);

            return RedirectToAction(nameof(Details), new { id = newOnHandExperienceId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await skillService.ExistsOnHandAsync(id) == false)
            {
                return BadRequest();
            }

            if (await onHandService.HasCreatorWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var model = await onHandService.GetOnHandFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, OnHandFormModel model)
        {
            if (await skillService.ExistsOnlineAsync(id) == false)
            {
                return BadRequest();
            }

            if (await onHandService.HasCreatorWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await onHandService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await onHandService.AllCategoriesAsync();
                return View(model);
            }

            await onHandService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new OnHandDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OnHandDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
