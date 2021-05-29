using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Data.Migrations
{
    public partial class addendum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addendum",
                columns: table => new
                {
                    Addendum_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HOA_Addendum = table.Column<bool>(type: "bit", nullable: false),
                    Delayed_Possession_Addendum = table.Column<bool>(type: "bit", nullable: false),
                    Contingent_Addendum = table.Column<bool>(type: "bit", nullable: false),
                    Other_Addendum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addendum", x => x.Addendum_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addendum");
        }
    }
}
