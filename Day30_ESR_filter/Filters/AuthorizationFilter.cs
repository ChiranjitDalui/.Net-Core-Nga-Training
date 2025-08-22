// here we are going to create a custom authorization filter for checking access to manager only able to check salaries

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeesManagement.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var role = context.HttpContext.Request.Headers["X-Role"].ToString();
            if (!string.Equals(role, "Manager", StringComparison.OrdinalIgnoreCase))// here we are ignoring case sensitivity
            {
                context.Result = new ContentResult { StatusCode = 403, Content = "Forbidden: Manager role required." };
            }
        }
    }
}