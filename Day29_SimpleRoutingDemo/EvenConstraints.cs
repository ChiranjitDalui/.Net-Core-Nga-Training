// This file contains constraints for even numbers
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

// This class contains constraints for even numbers
public class EvenConstraints : IRouteConstraint
{
   public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
   {
       if (httpContext == null || route == null || values == null)
       {
           throw new ArgumentNullException(nameof(httpContext));
       }
        //    if (values.TryGetValue(routeKey, out var value) && value is int number)
        //    {
        //         return number % 2 == 0;
        //         //    Here we are checking if the number is even
        //         // Real life example: Checking if a user's age is even
        //     }

        // By using TryParse we can avoid the need for explicit type checking
       if (int.TryParse(values[routeKey]?.ToString(), out int number))
       {
           return number % 2 == 0;
       }
       return false;
   }
}
