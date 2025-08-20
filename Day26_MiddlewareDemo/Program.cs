var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Middleware 1: Log all requests
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request received for: {context.Request.Path}");
    await next();
});

// Middleware 2: simple authentication  check
app.Use(async (context, next) =>
{
    if (context.Request.Query.TryGetValue("auth", out var authkey) && authkey == "secret")
    {
        Console.WriteLine("Authentication successful.");
        await next();
    }
    else
    {
        context.Response.StatusCode = 401; // Unauthorized
        await context.Response.WriteAsync("Unauthorized access. Please provide a valid auth key.");
    }
    
});


// Middleware 3: Serving static files that is present in wwwroot folder
app.UseStaticFiles();

// Middleware 4: Exception handling 
app.UseExceptionHandler("/error");


app.MapGet("/", () => "Hello World!");

app.Run();
