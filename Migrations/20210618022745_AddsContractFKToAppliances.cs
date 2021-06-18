using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class AddsContractFKToAppliances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Appliance",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Appliance_ContractId",
                table: "Appliance",
                column: "ContractId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appliance_Contract_ContractId",
                table: "Appliance",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appliance_Contract_ContractId",
                table: "Appliance");

            migrationBuilder.DropIndex(
                name: "IX_Appliance_ContractId",
                table: "Appliance");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Appliance");
        }
    }
}
