using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyWC.DataModels.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    City = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__People__3214EC07587720CB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Phone__3214EC071BBC3410", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Phone__PeopleId__267ABA7A",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Кемерово", "Денис", "Хорошевский" },
                    { 2, "Омск", "Ольга", "Корнелюк" },
                    { 3, "Томск", "Вадим", "Сапрыгин" },
                    { 4, "Орск", "Александр", "Великий" },
                    { 5, "Оренбург", "Виктория", "Дайнеко" },
                    { 6, "Москва", "Демис", "Карибидис" },
                    { 7, "Кемерово", "Сергей", "Силиванов" },
                    { 8, "Красноярск", "Тимур", "Спайкин" },
                    { 9, "Новокузнецк", "Ксения", "Ловачева" },
                    { 10, "Прокопьевск", "Ольга", "Реснина" },
                    { 11, "Иркутск", "Вячеслав", "Степной" }
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "PeopleId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "89132996666" },
                    { 2, 2, "89231234567" },
                    { 3, 3, "89230254567" },
                    { 4, 4, "89236204567" },
                    { 5, 5, "89231223567" },
                    { 6, 6, "89231254567" },
                    { 7, 7, "89233814567" },
                    { 8, 8, "89231200567" },
                    { 9, 9, "89231241567" },
                    { 10, 10, "89231226567" },
                    { 11, 11, "89832171511" },
                    { 12, 1, "89832171511" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phone_PeopleId",
                table: "Phone",
                column: "PeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
