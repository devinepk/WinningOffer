using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class addsContractIdtoFeulPropane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "FuelPropane",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FuelPropane_ContractId",
                table: "FuelPropane",
                column: "ContractId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelPropane_Contract_ContractId",
                table: "FuelPropane",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuelPropane_Contract_ContractId",
                table: "FuelPropane");

            migrationBuilder.DropIndex(
                name: "IX_FuelPropane_ContractId",
                table: "FuelPropane");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "FuelPropane");
        }
    }
}
