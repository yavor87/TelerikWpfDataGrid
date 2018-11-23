using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false),
                    Department = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Department", "FirstName", "LastName", "Salary" },
                values: new object[] { 1, "Marketing", "John", "Doe", 25000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Department", "FirstName", "LastName", "Salary" },
                values: new object[] { 2, "Marketing", "Peter", "Peterson", 27000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Department", "FirstName", "LastName", "Salary" },
                values: new object[] { 3, "Engineering", "Mark", "Harison", 35000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Department", "FirstName", "LastName", "Salary" },
                values: new object[] { 4, "Engineering", "David", "Peterson", 38000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Department", "FirstName", "LastName", "Salary" },
                values: new object[] { 5, "Engineering", "Dave", "Nickleson", 24000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
