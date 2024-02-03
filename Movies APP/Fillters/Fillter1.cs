using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Game_APP.Fillters
{
    public class Filter1 : IActionFilter
    {
        private readonly ILogger<Filter1> _logger;

        public Filter1(ILogger<Filter1> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Logic to be executed before the action method
            _logger.LogInformation("Executing action...");

            // You can also access the action parameters and other context information
            var actionParameters = context.ActionArguments;
            // Add more logic as needed

            _logger.LogInformation($"{actionParameters}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Logic to be executed after the action method
            _logger.LogInformation("Action executed successfully...");

            // You can access the result of the action execution and other context information
            var result = context.Result;
            // Add more logic as needed
            _logger.LogInformation($"{result}");

        }
    }

}

