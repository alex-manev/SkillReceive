using Microsoft.AspNetCore.Mvc;

namespace SkillReceive.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard() 
        {
            return View();
        }

        public async Task<IActionResult> ForReview() 
        {
            return View();
        }
    }
}
