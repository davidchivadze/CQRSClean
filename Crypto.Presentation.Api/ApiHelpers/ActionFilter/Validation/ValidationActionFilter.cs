using Crypto.Domain.Models.Responses.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Crypto.Presentation.Api.ApiHelpers.ActionFilter.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new List<string>();

                foreach (var modelState in context.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                context.Result = new BadRequestObjectResult(new Response<object>(HttpStatusCode.BadRequest, errors));
            }
        }
    }
}
