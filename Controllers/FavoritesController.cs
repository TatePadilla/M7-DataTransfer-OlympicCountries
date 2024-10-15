using M7_DataTransfer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace M7_DataTransfer.Controllers
{
    public class FavoritesController : Controller
    {
        private CountryContext context;
        public FavoritesController(CountryContext ctx) => context = ctx; 
        
        // Index() method is called when users select "Favorite Countries" link.
        [HttpGet]
        public ViewResult Index()
        {
            // Creating Olympic session, passing the session property of the controllers HttpContext property.
            var session = new OlympicSession(HttpContext.Session); 

            // Creating new CountryViewModel using the Olympic session to load it with data from the session state.
            var model = new CountryViewModel
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCategory = session.GetActiveCategory(),
                Countries = session.GetMyCountries()
            }; 
            return View(model);
        }

        // Called when the user clicks the "Add to Favorites" button.
        [HttpPost]
        public RedirectToActionResult Add(Country Country)
        {
            // Receives CountryID posted by the form and stores in the CountryID property of the Country that's in the parameter of this method.
            Country = context.Countries
                .Include(c => c.Game)
                .Include(c => c.Category)
                .Where(t => t.CountryID == Country.CountryID)
                .FirstOrDefault() ?? new Country();

            // Creating new OlympicSession
            var session = new OlympicSession(HttpContext.Session); 
            var Countries = session.GetMyCountries();

            // Adding stored favorites team to updated list in session state.
            Countries.Add(Country);
            session.SetMyCountries(Countries);

            // Giving user message regarding the country that was added to favorites.
            TempData["message"] = $"{Country.Name} added to your favorites"; 
            return RedirectToAction("Index", "Home", new
            {
                ActiveConf = session.GetActiveGame(),
                ActiveDiv = session.GetActiveCategory()
            });
        }
        [HttpPost]
        public RedirectToActionResult Delete()
        {
            // Creating new OlympicSession and passing it the Session property of the controllers HttpContext property.
            var session = new OlympicSession(HttpContext.Session); 

            // Removing list of countries and country count from session state.
            session.RemoveMyCountries();

            // Notify user and redirect to home page
            TempData["message"] = "Favorite Countries cleared"; 
            return RedirectToAction("Index", "Home", 
                new {
                    ActiveConf = session.GetActiveGame(), 
                    ActiveDiv = session.GetActiveCategory()
                }); 
        }
    }
}
