using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightningOffer.Data.Migrations
{
    public partial class contractpropertyfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Property",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Property_ContractId",
                table: "Property",
                column: "ContractId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Contract_ContractId",
                table: "Property",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Contract_ContractId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_ContractId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Property");
        }
    }
}
