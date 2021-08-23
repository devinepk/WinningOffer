using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class AddsAppraisalCompletedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AppraisalCompletedBy",
                table: "Appraisal",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppraisalCompletedBy",
                table: "Appraisal");
        }
    }
}
