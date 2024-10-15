namespace M7_DataTransfer.Models
{
    public class CountryViewModel
    {
        // Creating ActiveGame and ActiveCategory properties to be used for selection categories in Index view.
        public string ActiveGame { get; set; } = "all";
        public string ActiveCategory { get; set; } = "all";

        // Property to store a single team, used in Favorites.
        public Country Country { get; set; } = new Country();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<Game> Games { get; set; } = new List<Game>();
        public List<Category> Categories { get; set; } = new List<Category>();


        // methods to help view determine active link.
        public string CheckActiveGame(string g) => g.ToLower() == ActiveGame.ToLower() ? "active" : "";
        public string CheckActiveCategory(string c) => c.ToLower() == ActiveCategory.ToLower() ? "active" : "";

    }
}
