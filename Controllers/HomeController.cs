using M7_DataTransfer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace M7_DataTransfer.Controllers
{
    public class HomeController : Controller
    {
        // Creating DB context object.
        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        // Method used by the index view to display the CountryViewModel.
        public ViewResult Index(CountryViewModel model)
        {
            // Storing provided games & categories within the properties of the ViewModel class.
            model.Games = context.Games.ToList();
            model.Categories = context.Categories.ToList();

            // Creating query object ordered by country alphabetically.
            IQueryable<Country> query = context.Countries.OrderBy(c => c.Name);

            // Using ActiveGame and ActiveCategory properties of the view model to determine which are active.
            if (model.ActiveGame != "all")
            {
                query = query.Where(t => t.Game.GameID.ToLower() == model.ActiveGame.ToLower());
            }
            if (model.ActiveCategory != "all")
            {
                query = query.Where(t => t.Category.CategoryID.ToLower() == model.ActiveCategory.ToLower());
            }
            // Executing the built query and storing results in the Countries property of the view model, returning the model to the view.
            model.Countries = query.ToList(); return View(model);
        }

        // Method used by the details view to display selected country flag/information.
        public IActionResult Details(string id)
        {
            var country = context.Countries
                .Include(c => c.Game)
                .Include(c => c.Category)
                .FirstOrDefault(c => c.CountryID == id) ?? new Country(); return View(country);
        }
    }
}
