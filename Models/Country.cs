namespace M7_DataTransfer.Models
{
    public class Country
    {
        public string CountryID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Game Game { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public string Flag { get; set; } = string.Empty;

    }
}
