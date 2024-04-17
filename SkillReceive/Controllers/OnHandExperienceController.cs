using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Attributes;
using SkillReceive.Core.Contracts;
using SkillReceive.Core.Contracts.Creator;
using SkillReceive.Core.Contracts.OnHandExperience;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Exceptions;
using SkillReceive.Core.Models.Skill.OnHandExperience;
using System.Security.Claims;
using static SkillReceive.Core.Constants.MessageConstants;

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
            TempData[UserMessageSuccess] = "Skill added";

            return RedirectToAction(nameof(Details), new { id = newOnHandExperienceId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await skillService.ExistsOnHandAsync(id) == false)
            {
                return BadRequest();
            }

            if (await onHandService.HasCreatorWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
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

            if (await onHandService.HasCreatorWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
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

            TempData[UserMessageSuccess] = "Skill edited";
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await skillService.ExistsOnHandAsync(id) == false)
            {
                return BadRequest();
            }

            if (await onHandService.HasCreatorWithIdAsync(id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var onhandExp = await skillService.OnHandDetailsByIdAsync(id);

            var model = new OnHandDetailsViewModel()
            {
                Id = id,
                ImageURL = onhandExp.ImageURL,
                Title = onhandExp.Title,
                Location = onhandExp.Location,
                Requirements = onhandExp.Requirements
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OnHandDetailsViewModel model)
        {
            if (await skillService.ExistsOnHandAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await onHandService.HasCreatorWithIdAsync(model.Id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await skillService.DeleteOnHandAsync(model.Id);
            TempData[UserMessageSuccess] = "Skill deleted";

            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            if (await skillService.ExistsOnHandAsync(id) == false)
            {
                return BadRequest();
            }

            try
            {
                if (await creatorService.ExistsByIdAsync(User.Id()) && User.IsAdmin() == false)
                {
                    throw new UnauthorizedActionException();
                }

                await skillService.JoinOnHandAsync(id, User.Id());

                TempData[UserMessageSuccess] = "You have joined the course successfully";
            }
            catch (Exception)
            {
                TempData[UserMessageError] = "You have already joined this course";
            }

            return RedirectToAction(nameof(Mine), "Skill");
        }

    }
}
