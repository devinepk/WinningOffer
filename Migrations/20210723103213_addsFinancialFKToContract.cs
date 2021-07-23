using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class addsFinancialFKToContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Financial",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Financial",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Financial_ContractId",
                table: "Financial",
                column: "ContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Financial_UserId",
                table: "Financial",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_AspNetUsers_UserId",
                table: "Financial",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_Contract_ContractId",
                table: "Financial",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_AspNetUsers_UserId",
                table: "Financial");

            migrationBuilder.DropForeignKey(
                name: "FK_Financial_Contract_ContractId",
                table: "Financial");

            migrationBuilder.DropIndex(
                name: "IX_Financial_ContractId",
                table: "Financial");

            migrationBuilder.DropIndex(
                name: "IX_Financial_UserId",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Financial");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Financial");
        }
    }
}
