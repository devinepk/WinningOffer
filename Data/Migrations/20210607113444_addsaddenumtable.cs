using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Data.Migrations
{
    public partial class addsaddenumtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addendum_Contract_Contract_id",
                table: "Addendum");

            migrationBuilder.DropIndex(
                name: "IX_Addendum_Contract_id",
                table: "Addendum");

            migrationBuilder.DropColumn(
                name: "Contract_Id",
                table: "Addendum");

            migrationBuilder.DropColumn(
                name: "Contract_id",
                table: "Addendum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
