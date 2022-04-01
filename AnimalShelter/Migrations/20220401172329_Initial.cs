using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cat",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Dog",
                columns: table => new
                {
                    DogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.DogId);
                });

            migrationBuilder.InsertData(
                table: "Cat",
                columns: new[] { "CatId", "Age", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Female", "Catrina McMeow" },
                    { 2, 2, "Male", "Henry Hiss" },
                    { 3, 2, "Female", "Pamela Pushitoff" },
                    { 4, 3, "Male", "Benjamin Bartholomeow" }
                });

            migrationBuilder.InsertData(
                table: "Dog",
                columns: new[] { "DogId", "Age", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Male", "Mathias McDog" },
                    { 2, 2, "Female", "Sally Sandwichstealer" },
                    { 3, 2, "Male", "Peter Poopeater" },
                    { 4, 3, "Female", "Samantha Sniffsalot" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cat");

            migrationBuilder.DropTable(
                name: "Dog");
        }
    }
}
