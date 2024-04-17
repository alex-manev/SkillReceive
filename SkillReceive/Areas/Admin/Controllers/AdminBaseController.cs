using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SkillReceive.Core.Constants.AdminConstants;

namespace SkillReceive.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}
