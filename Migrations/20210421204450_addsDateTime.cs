using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinningOffer.Migrations
{
    public partial class addsDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Propane",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owned = table.Column<bool>(type: "bit", nullable: false),
                    Leaded = table.Column<bool>(type: "bit", nullable: false),
                    WillRemain = table.Column<bool>(type: "bit", nullable: false),
                    NotRemain = table.Column<bool>(type: "bit", nullable: false),
                    NotApplication = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propane", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propane");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Item");
        }
    }
}
