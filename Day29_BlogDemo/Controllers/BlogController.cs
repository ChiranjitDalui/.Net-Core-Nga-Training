using Day29_BlogDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day29_BlogDemo.Controllers
{
    // Blog controller for managing blog posts
    public class BlogController : Controller
    {
        // In-memory data store
        private static List<BlogPost> blogPosts = new List<BlogPost>
        {
            new BlogPost { Id = 1, Title = "What is ASP.NET Core?", Slug = "what-is-aspnet-core", Content = "ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, Internet-connected applications.", CreatedAt = DateTime.Now },
            new BlogPost { Id = 2, Title = "Getting Started with ASP.NET Core", Slug = "getting-started-aspnet-core", Content = "Here are some steps to get started with ASP.NET Core.", CreatedAt = DateTime.Now },
            new BlogPost { Id = 3, Title = "Understanding MVC in ASP.NET Core", Slug = "understanding-mvc-aspnet-core", Content = "This is the content of the third post.", CreatedAt = DateTime.Now },
            new BlogPost { Id = 4, Title = "Building RESTful APIs with ASP.NET Core", Slug = "building-restful-apis-aspnet-core", Content = "Learn how to build RESTful APIs using ASP.NET Core.", CreatedAt = DateTime.Now }
        };

        // Action methods
        // Details(string slug)
        // Adding Route
        [Route("blog/{slug}")]
        public IActionResult Details(string slug)
        {
            var post = blogPosts.FirstOrDefault(p => p.Slug == slug);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // Index
        public IActionResult Index()
        {
            return View(blogPosts);
        }
    }
}