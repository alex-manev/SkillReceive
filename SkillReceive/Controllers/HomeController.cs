using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Models.Home;
using SkillReceive.Models;
using System.Diagnostics;

namespace SkillReceive.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;

        private readonly ISkillService skillService;

        public HomeController(ILogger<HomeController> _logger, ISkillService _skillService)
        {
            logger = _logger;
            skillService = _skillService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await skillService.LastFourSkillsAsync();

            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {

            if (statusCode == 400)
            {
                return View("Error400");
            }


            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
