using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Day26_RazorIntro.Pages.Shared
{
    public class Demo1Model : PageModel
    {

        // Property to bound to the page

        public string Message { get; set; } = "Hello from Demo1!";
        // 

        public void OnGet()
        {
            // This method is called when the page is accessed via a GET request
            // You can initialize properties or perform actions here
            Message = "Welcome to the Demo1 page!";
        }

        public void OnPost()
        {
            // This method is called when the page is accessed via a POST request
            // You can handle form submissions or other actions here
            Message = "You submitted the form!";
        }
    }
}
