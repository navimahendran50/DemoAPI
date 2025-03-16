using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoAPI.Filters
{
    public class GlobalModelValidationExceptionHandler : IActionFilter
    {
        private readonly ILogger<GlobalModelValidationExceptionHandler> logger;
        public GlobalModelValidationExceptionHandler(ILogger<GlobalModelValidationExceptionHandler> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var hasParameters = context.ActionDescriptor.Parameters.Any();

            logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} has parameters: {hasParameters}");

            if (hasParameters)
            {
                if (!context.ActionArguments.Any() || context.ActionArguments.All(arg => arg.Value == null))
                {
                    context.Result = new BadRequestObjectResult(new
                    {
                        Errors = new List<string> { "Request cannot be empty" }
                    });

                    return;
                }
                var modelState = context.ModelState;
                if (!modelState.IsValid)
                {
                    var errors = new List<string>();
                    foreach (var state in modelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                    }
                    logger.LogError($"Model validation failed for action {context.ActionDescriptor.DisplayName}, errors: {string.Join(", ", errors)}");
                    context.Result = new BadRequestObjectResult(new { Errors = errors });
                }
            }

        }
    }
}