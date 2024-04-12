using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Attributes;
using SkillReceive.Core.Contracts.Creator;
using SkillReceive.Core.Contracts.OnlineCourse;
using SkillReceive.Core.Models.Skill.OnlineCourse;
using System.Security.Claims;

namespace SkillReceive.Controllers
{
    
    public class OnlineCourseController : BaseController
    {
        private readonly ICreatorService creatorService;
        private readonly IOnlineCourseService onlineCourseService;

        public OnlineCourseController(ICreatorService _creatorService, IOnlineCourseService _onlineCourseService)
        {
            creatorService = _creatorService;
            onlineCourseService = _onlineCourseService;
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
        public async Task<IActionResult> Details()
        {
            var model = new OnlineDetailsViewModel();

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
                ModelState.AddModelError(nameof(model.CategoryId), "");
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
            var model = new OnlineFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, OnlineFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new OnlineDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OnlineDetailsViewModel model)
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
