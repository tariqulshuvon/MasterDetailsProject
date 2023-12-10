using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticalTaskGNIS.Migrations
{
    /// <inheritdoc />
    public partial class CorporateOrIndividualAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.CreateTable(
                name: "CorporateOrIndividual",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateOrIndividualCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateOrIndividual", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateOrIndividual");

            migrationBuilder.CreateTable(
                name: "Meeting_Minutes_Details_Tbl",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateOrIndividual = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MeetingPlace = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting_Minutes_Details_Tbl", x => x.Id);
                });
        }
    }
}
