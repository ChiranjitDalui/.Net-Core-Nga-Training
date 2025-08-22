using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EmployeesManagement.Filters
{
    public class LoggingActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;
        public LoggingActionFilter(ILogger<LoggingActionFilter> logger) => _logger = logger;


        // step 1 Input validation we are doing
        //step 2 Start Measuring Time and Logging
        // step 3. End Measuring Time and Logging
        // step 4. Log Result.
        public async Task OnActionExecutionAsync(ActionExecutingContext ctx, ActionExecutionDelegate next)
        {

            // Simple input guard
            if (ctx.ActionArguments.TryGetValue("id", out var val) &&
                val is int id && id <= 0)// checing int and some validation of end conditions.
            {
                ctx.Result = new BadRequestObjectResult("Order id must be > 0.");
                return;
            }
            Console.WriteLine($"Checking OnActionExecutionAsync order id :{val}");

            var sw = Stopwatch.StartNew();
            _logger.LogInformation("Action start: {Action}", ctx.ActionDescriptor.DisplayName);

            // Execute the action
            var executed = await next();
        
            // if(!executed.Result is OkObjectResult)
            sw.Stop();
            _logger.LogInformation("Action end: {Action} in {Ms}ms", ctx.ActionDescriptor.DisplayName, sw.ElapsedMilliseconds);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} is executing.");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} has executed.");
        }
    }
}