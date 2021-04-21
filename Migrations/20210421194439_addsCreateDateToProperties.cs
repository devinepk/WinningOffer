using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinningOffer.Migrations
{
    public partial class addsCreateDateToProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Property",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Refrigerator = table.Column<bool>(type: "bit", nullable: false),
                    DishWasher = table.Column<bool>(type: "bit", nullable: false),
                    OvenRange = table.Column<bool>(type: "bit", nullable: false),
                    WallOven = table.Column<bool>(type: "bit", nullable: false),
                    ClothesWasher = table.Column<bool>(type: "bit", nullable: false),
                    ClothesDryer = table.Column<bool>(type: "bit", nullable: false),
                    Microwave = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Property");
        }
    }
}
