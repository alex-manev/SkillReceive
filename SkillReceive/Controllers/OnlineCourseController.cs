using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Core.Models.Skill.OnlineCourse;

namespace SkillReceive.Controllers
{
    
    public class OnlineCourseController : BaseController
    {
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
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(OnlineFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
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
