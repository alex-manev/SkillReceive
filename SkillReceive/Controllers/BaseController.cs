using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SkillReceive.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
