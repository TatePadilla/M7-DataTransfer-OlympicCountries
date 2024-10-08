using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace M7_DataTransfer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { "indoor", "Indoor" },
                    { "outdoor", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "Name" },
                values: new object[,]
                {
                    { "paralympics", "Paralympics" },
                    { "summer", "Summer Olympics" },
                    { "winter", "Winter Olympics" },
                    { "youth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CategoryID", "Flag", "GameID", "Name" },
                values: new object[,]
                {
                    { "at", "outdoor", "austria.png", "paralympics", "Austria" },
                    { "br", "outdoor", "brazil.png", "summer", "Brazil" },
                    { "ca", "indoor", "canada.png", "winter", "Canada" },
                    { "cn", "indoor", "china.png", "summer", "China" },
                    { "cy", "indoor", "cyprus.png", "youth", "Cyprus" },
                    { "de", "indoor", "germany.png", "summer", "Germany" },
                    { "fi", "outdoor", "finland.png", "youth", "Finland" },
                    { "fr", "indoor", "france.png", "youth", "France" },
                    { "gb", "indoor", "greatbritain.png", "winter", "Great Britain" },
                    { "it", "outdoor", "italy.png", "winter", "Italy" },
                    { "jm", "outdoor", "jamaica.png", "winter", "Jamaica" },
                    { "jp", "outdoor", "japan.png", "winter", "Japan" },
                    { "mx", "indoor", "mexico.png", "summer", "Mexico" },
                    { "nl", "outdoor", "netherlands.png", "summer", "Netherlands" },
                    { "pk", "outdoor", "pakistan.png", "paralympics", "Pakistan" },
                    { "pt", "outdoor", "portugal.png", "youth", "Portugal" },
                    { "ru", "indoor", "russia.png", "youth", "Russia" },
                    { "se", "indoor", "sweden.png", "winter", "Sweden" },
                    { "sk", "outdoor", "slovakia.png", "youth", "Slovakia" },
                    { "th", "indoor", "thailand.png", "paralympics", "Thailand" },
                    { "ua", "indoor", "ukraine.png", "paralympics", "Ukraine" },
                    { "us", "outdoor", "usa.png", "summer", "USA" },
                    { "uy", "indoor", "uruguay.png", "paralympics", "Uruguay" },
                    { "zw", "outdoor", "zimbabwe.png", "paralympics", "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CategoryID",
                table: "Countries",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
