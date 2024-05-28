using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerceServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class companyetitysiolusturuldu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    TaxDepartment = table.Column<int>(type: "integer", maxLength: 11, nullable: false),
                    TaxNumber = table.Column<string>(type: "text", nullable: false),
                    address_country = table.Column<string>(type: "varchar(50)", nullable: false),
                    address_city = table.Column<string>(type: "varchar(50)", nullable: false),
                    address_town = table.Column<string>(type: "varchar(50)", nullable: false),
                    address_street = table.Column<string>(type: "varchar(50)", nullable: false),
                    address_full_address = table.Column<string>(type: "varchar(200)", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
