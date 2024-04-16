using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Attributes;
using SkillReceive.Core.Contracts.Creator;
using SkillReceive.Core.Contracts.OnlineCourse;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Models.Skill.OnlineCourse;
using System.Security.Claims;

namespace SkillReceive.Controllers
{
    
    public class OnlineCourseController : BaseController
    {
        private readonly ICreatorService creatorService;
        private readonly IOnlineCourseService onlineCourseService;
        private readonly ISkillService skillService;

        public OnlineCourseController(ICreatorService _creatorService, IOnlineCourseService _onlineCourseService, ISkillService _skillService)
        {
            creatorService = _creatorService;
            onlineCourseService = _onlineCourseService;
            skillService = _skillService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllOnlineQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new AllOnlineQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await skillService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await skillService.OnlineDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        [MustBeCreator]
        public async Task<IActionResult> Add()
        {

            var model = new OnlineFormModel() 
            {
                Categories = await onlineCourseService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeCreator]
        public async Task<IActionResult> Add(OnlineFormModel model)
        {
            if (await onlineCourseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await onlineCourseService.AllCategoriesAsync();

                return View(model);
            }

            int? creatorId = await creatorService.GetCreatorIdAsync(User.Id());

            int newOnlineCourseId = await onlineCourseService.CreateAsync(model, creatorId ?? 0);

            return RedirectToAction(nameof(Details), new { id = newOnlineCourseId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await skillService.ExistsOnlineAsync(id) == false)
            {
                return BadRequest();
            }

            if (await onlineCourseService.HasCreatorWithIdAsync(id, User.Id())  == false)
            {
                return Unauthorized();
            }

            var model = await onlineCourseService.GetOnlineFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, OnlineFormModel model)
        {
            if (await skillService.ExistsOnlineAsync(id) == false)
            {
                return BadRequest();
            }

            if (await onlineCourseService.HasCreatorWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await onlineCourseService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await onlineCourseService.AllCategoriesAsync();

                return View(model);
            }

            await onlineCourseService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await skillService.ExistsOnlineAsync(id) == false)
            {
                return BadRequest();
            }

            if (await onlineCourseService.HasCreatorWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var onlineCourse = await skillService.OnlineDetailsByIdAsync(id);

            var model = new OnlineDetailsViewModel()
            {
                Id = id,
                ImageURL = onlineCourse.ImageURL,
                Title = onlineCourse.Title,
                NeededTechnologies = onlineCourse.NeededTechnologies
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OnlineDetailsViewModel model)
        {
            if (await skillService.ExistsOnlineAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await onlineCourseService.HasCreatorWithIdAsync(model.Id, User.Id()) == false)
            {
                return Unauthorized();
            }

            await skillService.DeleteOnlineAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            if (await skillService.ExistsOnlineAsync(id) == false)
            {
                return BadRequest();
            }

            if (await creatorService.ExistsByIdAsync(User.Id()))
            {
                return Unauthorized();
            }

            await skillService.JoinOnlineAsync(id, User.Id());

            return RedirectToAction(nameof(Mine),"Skill");
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (await skillService.ExistsOnlineAsync(id) == false)
            {
                return BadRequest();
            }

            if (await creatorService.ExistsByIdAsync(User.Id()))
            {
                return Unauthorized();
            }

            await skillService.LeaveOnline(id, User.Id());

            return RedirectToAction(nameof(Mine), "Skill");
        }
    }
}
