using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Gender", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Male", "Mathias McDog", "Dog" },
                    { 2, 2, "Female", "Sally Sandwichstealer", "Dog" },
                    { 3, 2, "Male", "Peter Poopeater", "Dog" },
                    { 4, 3, "Female", "Samantha Sniffsalot", "Dog" },
                    { 5, 1, "Female", "Catrina McMeow", "Cat" },
                    { 6, 2, "Male", "Henry Hiss", "Cat" },
                    { 7, 2, "Female", "Pamela Pushitoff", "Cat" },
                    { 8, 3, "Male", "Benjamin Bartholomeow", "Cat" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
