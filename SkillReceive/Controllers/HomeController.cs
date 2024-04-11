using Microsoft.AspNetCore.Mvc;
using SkillReceive.Core.Contracts.Skill;
using SkillReceive.Core.Models.Home;
using SkillReceive.Models;
using System.Diagnostics;

namespace SkillReceive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        private readonly ISkillService skillService;

        public HomeController(ILogger<HomeController> _logger, ISkillService _skillService)
        {
            logger = _logger;
            skillService = _skillService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await skillService.LastFourSkills();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
