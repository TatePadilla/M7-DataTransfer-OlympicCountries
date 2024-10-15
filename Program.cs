using M7_DataTransfer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// For storing session data in memory.
builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options =>
{
    // Setting session timeout duration.
    options.IdleTimeout = TimeSpan.FromMinutes(30);

    // Required for session state to function.
    options.Cookie.IsEssential = true; 
});

// Add EF Core dependency injection, allowing the DbContext objects to be properly passed to controllers.
builder.Services.AddDbContext<CountryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CountryContext")));

// Making URLs lowercase and end with a trailing slash.
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// This line enables session state
app.UseSession();  

app.UseAuthorization();

// Mapping custom route that uses two static literals (game- and category-) as well as two required parameters (activeGame, activeCategory).
app.MapControllerRoute(
    name: "custom",
    pattern: "{controller}/{action}/game-{activeGame}/category-{activeCategory}",
    defaults: new { activeGame = "all", activeCategory = "all" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();