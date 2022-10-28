using Microsoft.EntityFrameworkCore.Migrations;

namespace animalshelterapi.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Breed", "Color", "IsFixed", "Name", "Sex", "Species" },
                values: new object[,]
                {
                    { 1, 6, "pit bull mix", "White", true, "Titan", "male", "canine" },
                    { 2, 3, "pit bull mix", "brown", true, "Milo", "male", "canine" },
                    { 3, 4, "Shepherd Mix", "Black", true, "Korra", "female", "canine" },
                    { 4, 1, "american shorthair", "black", true, "Sid", "male", "feline" },
                    { 5, 1, "mixed", "tabby", true, "Maeve", "female", "feline" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
