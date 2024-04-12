using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SkillReceive.Core.Contracts.Creator;
using System.Security.Claims;
using SkillReceive.Controllers;

namespace SkillReceive.Attributes
{
    public class MustBeCreator : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ICreatorService? creatorService = context.HttpContext.RequestServices.GetService<ICreatorService>();

            if (creatorService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (creatorService != null && creatorService.ExistsByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(CreatorController.Become), "Creator", null);
            }


        }
    }
}
