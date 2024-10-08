using M7_DataTransfer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core dependency injection, allowing the DbContext objects to be properly passed to controllers.
builder.Services.AddDbContext<CountryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CountryContext")));

// Making URL's lowercase and end with a trailing slash.
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true; options.AppendTrailingSlash = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapping custom route that uses two static literals (game- and category-) as well as two required parameters (activeGame, activeCategory).
// Deafult values are set to all when no specific game or category is selected.
app.MapControllerRoute(
    name: "custom",
    pattern: "{controller}/{action}/game-{activeGame}/category-{activeCategory}",
    defaults: new { activeGame = "all", activeCategory = "all" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
