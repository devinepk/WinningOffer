using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Migrations
{
    public partial class AddsAppraisalContractFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Appraisal",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Appraisal_ContractId",
                table: "Appraisal",
                column: "ContractId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appraisal_Contract_ContractId",
                table: "Appraisal",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appraisal_Contract_ContractId",
                table: "Appraisal");

            migrationBuilder.DropIndex(
                name: "IX_Appraisal_ContractId",
                table: "Appraisal");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Appraisal");
        }
    }
}
