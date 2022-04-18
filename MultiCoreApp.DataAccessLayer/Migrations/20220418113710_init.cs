using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class init : Migration
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
                    { new Guid("4c746c19-bb50-4ef2-85b5-51107ac5994f"), false, "Kalemler" },
                    { new Guid("f1742dd8-671d-4fec-8256-a5df06b20b60"), false, "Defterler" }
                });

            migrationBuilder.InsertData(
                table: "tblCustomers",
                columns: new[] { "Id", "Address", "City", "Email", "IsDeleted", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("7cafa287-7bd4-454b-9e01-3ba28ed2e172"), "Bayrampasa", "Istanbul", "kaang@gmail.com", false, "Kaan Gurbuz", "05555555555" },
                    { new Guid("d53a4b58-e6ad-4186-91c3-cbd2323e72eb"), "Rzeszow", "Krakow", "lid@gmail.com", false, "Lidia Mazur", "05552255555" }
                });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("063a332c-6b83-4d66-ac7a-59ac95107a8b"), new Guid("4c746c19-bb50-4ef2-85b5-51107ac5994f"), false, "Dolma Kalem", 122.53m, 100 },
                    { new Guid("1ee1808a-782b-4ab3-97bd-cdea17868458"), new Guid("f1742dd8-671d-4fec-8256-a5df06b20b60"), false, "Kareli Defter", 28.06m, 100 },
                    { new Guid("bcb8a340-bf66-4c95-9066-813d1f4b9637"), new Guid("f1742dd8-671d-4fec-8256-a5df06b20b60"), false, "Cizgili Defter", 22.53m, 100 },
                    { new Guid("bd3dc3dc-8cda-48f0-8669-c29545fb0e3d"), new Guid("4c746c19-bb50-4ef2-85b5-51107ac5994f"), false, "Kursun Kalem", 62.19m, 100 },
                    { new Guid("c3efeda8-d795-44fd-b839-c6c3a4f52945"), new Guid("4c746c19-bb50-4ef2-85b5-51107ac5994f"), false, "Tukenmez Kalem", 18.06m, 100 },
                    { new Guid("c4336963-675f-4088-9f02-beed3ed905c7"), new Guid("f1742dd8-671d-4fec-8256-a5df06b20b60"), false, "Dumduz Defter", 12.19m, 0 }
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
                name: "tblCategories");
        }
    }
}
