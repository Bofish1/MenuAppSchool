using Microsoft.EntityFrameworkCore.Migrations;

namespace Menu.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Description", "Name", "Price" },
                values: new object[] { 1, "1/2lb Angus Patty Between a Sesame seed bun.", "Cheese Burger", 9.99m });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Description", "Name", "Price" },
                values: new object[] { 2, "Hot Ham and cheese on open faced french bread.", "Open-Face Ham Sandwich", 8.99m });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Description", "Name", "Price" },
                values: new object[] { 3, "Lettuce,Tomatoe,Red Onion, and Artichoke Hearts tossed in Italian Dressing.", "House Salad", 7.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
