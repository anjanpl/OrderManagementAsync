using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    AddresslineOne = table.Column<string>(maxLength: 50, nullable: false),
                    AddresslineTwo = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "AddresslineOne", "AddresslineTwo", "City", "Name", "PostalCode", "State" },
                values: new object[] { 1, "Houston", "AB", "Texas", "Anjan", "5458878", 4 });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "AddresslineOne", "AddresslineTwo", "City", "Name", "PostalCode", "State" },
                values: new object[] { 2, "California", "ABC", "California", "Ashis", "8898989", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
