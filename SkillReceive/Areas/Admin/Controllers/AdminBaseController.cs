using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SkillReceive.Core.Constants.RoleConstants;

namespace SkillReceive.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}
