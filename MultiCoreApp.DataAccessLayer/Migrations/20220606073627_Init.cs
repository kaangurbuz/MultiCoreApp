using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProducts_tblCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("3e20870b-d44d-453f-b6a9-b0bd5b4cc434"), false, "Defterler" },
                    { new Guid("8efe0abd-f2ff-473f-b138-2a8694de04bb"), false, "Kalemler" }
                });

            migrationBuilder.InsertData(
                table: "tblCustomers",
                columns: new[] { "Id", "Address", "City", "Email", "IsDeleted", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("34045d77-cd75-4823-9e1e-9826c6a73f36"), "Rzeszow", "Krakow", "lid@gmail.com", false, "Lidia Mazur", "05552255555" },
                    { new Guid("490fdc32-6a32-4de0-bd99-52f9fb997144"), "Bayrampasa", "Istanbul", "kaang@gmail.com", false, "Kaan Gurbuz", "05555555555" }
                });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("00b86e78-e967-4ed8-a8d0-cd63dfebd9d6"), new Guid("3e20870b-d44d-453f-b6a9-b0bd5b4cc434"), false, "Cizgili Defter", 22.53m, 100 },
                    { new Guid("13882485-a8e3-4dda-9ff0-8e0ab295d73d"), new Guid("8efe0abd-f2ff-473f-b138-2a8694de04bb"), false, "Kursun Kalem", 62.19m, 100 },
                    { new Guid("4cd5a420-d87c-48fd-b285-ea010a49dbef"), new Guid("3e20870b-d44d-453f-b6a9-b0bd5b4cc434"), false, "Dumduz Defter", 12.19m, 0 },
                    { new Guid("696ad48b-c077-41b3-be53-24cd9edb6f19"), new Guid("3e20870b-d44d-453f-b6a9-b0bd5b4cc434"), false, "Kareli Defter", 28.06m, 100 },
                    { new Guid("b9458b58-2fd8-4ffd-9330-e62d566b95c0"), new Guid("8efe0abd-f2ff-473f-b138-2a8694de04bb"), false, "Tukenmez Kalem", 18.06m, 100 },
                    { new Guid("b9aa70a8-aaf3-4245-ad71-32afb81e1ce1"), new Guid("8efe0abd-f2ff-473f-b138-2a8694de04bb"), false, "Dolma Kalem", 122.53m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_CategoryId",
                table: "tblProducts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomers");

            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "tblCategories");
        }
    }
}
