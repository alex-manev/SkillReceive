using Microsoft.AspNetCore.Mvc;
using SkillReceive.Core.Contracts;

namespace SkillReceive.Areas.Admin.Controllers
{
    public class JoinController : AdminBaseController
    {
        private readonly IJoinService joinService;

        public JoinController(IJoinService _joinService)
        {
            joinService = _joinService;
        }

        public async Task<IActionResult> All()
        {
            var model = await joinService.AllAsync();


            return View(model);
        }
    }
}
