using Microsoft.AspNetCore.Mvc.Filters;

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
            _logger.LogWarning("Executing action.{n}..", 2);
            // _logger.l

            // You can also access the action parameters and other context information
            var actionParameters = context.ActionArguments;
            // Add more logic as needed

            _logger.LogWarning($"{actionParameters}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Logic to be executed after the action method
            _logger.LogWarning("Action executed successfully...");
            _logger.LogDebug("mohamed................."); 

            // You can access the result of the action execution and other context information
            var result = context.Result;
             //var result =retue;

            // Add more logic as needed
            _logger.LogWarning($"{result}");

        }
    }

}

