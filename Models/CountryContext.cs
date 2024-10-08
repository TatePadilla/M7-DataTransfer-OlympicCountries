using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace M7_DataTransfer.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options) { }
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Creating DB entity objects for each game type.
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().HasData(
                new Game { GameID = "winter", Name = "Winter Olympics" },
                new Game { GameID = "summer", Name = "Summer Olympics" },
                new Game { GameID = "paralympics", Name = "Paralympics" },
                new Game { GameID = "youth", Name = "Youth Olympic Games" }
            );
            // Creating DB objects for each category type.
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = "indoor", Name = "Indoor" },
                new Category { CategoryID = "outdoor", Name = "Outdoor" }
            );
            // Creating DB entity objects for each country, tied into games & categories above.
            modelBuilder.Entity<Country>().HasData(
                new { CountryID = "ca", Name = "Canada", GameID = "winter", CategoryID = "indoor", Flag = "canada.png" },
                new { CountryID = "se", Name = "Sweden", GameID = "winter", CategoryID = "indoor", Flag = "sweden.png" },
                new { CountryID = "gb", Name = "Great Britain", GameID = "winter", CategoryID = "indoor", Flag = "greatbritain.png" },
                new { CountryID = "jm", Name = "Jamaica", GameID = "winter", CategoryID = "outdoor", Flag = "jamaica.png" },
                new { CountryID = "it", Name = "Italy", GameID = "winter", CategoryID = "outdoor", Flag = "italy.png" },
                new { CountryID = "jp", Name = "Japan", GameID = "winter", CategoryID = "outdoor", Flag = "japan.png" },
                new { CountryID = "de", Name = "Germany", GameID = "summer", CategoryID = "indoor", Flag = "germany.png" },
                new { CountryID = "cn", Name = "China", GameID = "summer", CategoryID = "indoor", Flag = "china.png" },
                new { CountryID = "mx", Name = "Mexico", GameID = "summer", CategoryID = "indoor", Flag = "mexico.png" },
                new { CountryID = "br", Name = "Brazil", GameID = "summer", CategoryID = "outdoor", Flag = "brazil.png" },
                new { CountryID = "nl", Name = "Netherlands", GameID = "summer", CategoryID = "outdoor", Flag = "netherlands.png" },
                new { CountryID = "us", Name = "USA", GameID = "summer", CategoryID = "outdoor", Flag = "usa.png" },
                new { CountryID = "th", Name = "Thailand", GameID = "paralympics", CategoryID = "indoor", Flag = "thailand.png" },
                new { CountryID = "uy", Name = "Uruguay", GameID = "paralympics", CategoryID = "indoor", Flag = "uruguay.png" },
                new { CountryID = "ua", Name = "Ukraine", GameID = "paralympics", CategoryID = "indoor", Flag = "ukraine.png" },
                new { CountryID = "at", Name = "Austria", GameID = "paralympics", CategoryID = "outdoor", Flag = "austria.png" },
                new { CountryID = "pk", Name = "Pakistan", GameID = "paralympics", CategoryID = "outdoor", Flag = "pakistan.png" },
                new { CountryID = "zw", Name = "Zimbabwe", GameID = "paralympics", CategoryID = "outdoor", Flag = "zimbabwe.png" },
                new { CountryID = "fr", Name = "France", GameID = "youth", CategoryID = "indoor", Flag = "france.png" },
                new { CountryID = "cy", Name = "Cyprus", GameID = "youth", CategoryID = "indoor", Flag = "cyprus.png" },
                new { CountryID = "ru", Name = "Russia", GameID = "youth", CategoryID = "indoor", Flag = "russia.png" },
                new { CountryID = "fi", Name = "Finland", GameID = "youth", CategoryID = "outdoor", Flag = "finland.png" },
                new { CountryID = "sk", Name = "Slovakia", GameID = "youth", CategoryID = "outdoor", Flag = "slovakia.png" },
                new { CountryID = "pt", Name = "Portugal", GameID = "youth", CategoryID = "outdoor", Flag = "portugal.png" }
            );
        }
    }
}


