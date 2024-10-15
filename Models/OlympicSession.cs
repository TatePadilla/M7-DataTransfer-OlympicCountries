namespace M7_DataTransfer.Models
{
    public class OlympicSession
    {
        // Defining 4 constants for key names to make changes easier and help avoid typos.
        private const string CountriesKey = "mycountries"; 
        private const string CountKey = "countrycount"; 
        private const string GameKey = "game"; 
        private const string CategoryKey = "category";
        private ISession session { get; set; }

        // Constructor accepting session, store value in private "session" property above.
        public OlympicSession(ISession session) => this.session = session;

        // Accepts list of countries, uses SetObject extension method (in SessionExtensions) to store the list of teams in a session state.
        // Stores count of teams in session state using SetInt32().
        public void SetMyCountries(List<Country> Countries)
        {
            session.SetObject(CountriesKey, Countries); 
            session.SetInt32(CountKey, Countries.Count);
        }

        // Retrieves Country Keys stored by SetMyCountries() method above, returns default value of "new List<Country>()" if none are given.
        public List<Country> GetMyCountries() =>
        session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>();

        // Retrieves CountryCount stored by SetMyCountries() method above.
        public int? GetMyCountryCount() => session.GetInt32(CountKey);

        // Note the use of SetString() to store a string in the session state.
        public void SetActiveGame(string activeGame) => session.SetString(GameKey, activeGame);

        // Note the use of GetString() to retrieve a string in the session state.
        public string GetActiveGame() => session.GetString(GameKey) ?? string.Empty;
        public void SetActiveCategory(string activeCategory) => session.SetString(CategoryKey, activeCategory); 
        public string GetActiveCategory() => session.GetString(CategoryKey) ?? string.Empty;

        // Uses Remove() method of the ISession interface to remove all data about favorite teams from session state.
        public void RemoveMyCountries()
        {
            session.Remove(CountriesKey); 
            session.Remove(CountKey);
        }
    }
}
