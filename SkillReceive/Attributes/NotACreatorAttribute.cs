using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SkillReceive.Core.Contracts.Creator;
using System.Security.Claims;

namespace SkillReceive.Attributes
{
    public class NotACreatorAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            ICreatorService? creatorService = context.HttpContext.RequestServices.GetService<ICreatorService>();

            if (creatorService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (creatorService != null && creatorService.ExistsByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }


        }
    }
}
