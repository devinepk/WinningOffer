using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinningOffer.Migrations
{
    public partial class dbupdateNoFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ARM_Limits",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Active_Lease",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "As_Is",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "BlockNum",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Buyer_Appraisal_Required",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Buyer_Inspection_Window",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Buyer_Loan_Application_Start",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Buyer_Title_Insurance",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Buyer_To_Pay_HW",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Buyer_To_Purchase_HW_Later",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Buyer_Waives_Lead_Paint_Inspection",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Buyer_Waves_Right_To_HW",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Cash",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Closing_Window",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Closing_Window_Latest",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Closing_Window_Soonest",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ClothesDryer",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ClothesWasher",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Contingent_Addendum",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Contingent_On_Lead_Paint",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Contingent_On_Survey",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Conventional",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "DeedBook",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Delayed_Possession_Addendum",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "DishWasher",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "EMD",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "EMD_With_ListingBroker",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "EMD_With_SellingBroker",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "FHA",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Fixed_Rate",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Gift",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "HOA_Addendum",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "HW",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "HW_Price",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ImageURLs",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Interest_Rate",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Keys_at_Closing",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Last_Best_Request_Window",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Lead_Paint_Inspection_Window",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Lender_Appraisal_Required",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "LineOfEquity",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ListAgent",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ListAgentPhone",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ListCompany",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Loan_Length",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "LotNum",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Microwave",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "MlsNumber",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "New_Construction_HW",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "No_Appraisal_Required",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "No_Lead_Paint",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Other_Addendum",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Other_Financing",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Other_Provisions",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Page",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Propane_Leased",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Propane_NotApplicable",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Propane_NotRemain",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Propane_Owned",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Propane_Will_Remain",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Purchase_Price",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Refrigerator",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Seller_Disclosure_Recieved",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Seller_Lead_Paint_Response_Window",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Seller_Repair_Request_Response_Window",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Seller_To_Pay_HW",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "StoveRange",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "SubLotNum",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "VA",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "Specific_Closing_Date",
                table: "Contract",
                newName: "SellingAgentSignedDate");

            migrationBuilder.RenameColumn(
                name: "Keys_after_Closing",
                table: "Contract",
                newName: "SellerSignedDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Contract",
                newName: "Contract_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "BuyerSignedDate",
                table: "Contract",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ListAgentSignedDate",
                table: "Contract",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerSignedDate",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ListAgentSignedDate",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "SellingAgentSignedDate",
                table: "Contract",
                newName: "Specific_Closing_Date");

            migrationBuilder.RenameColumn(
                name: "SellerSignedDate",
                table: "Contract",
                newName: "Keys_after_Closing");

            migrationBuilder.RenameColumn(
                name: "Contract_id",
                table: "Contract",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ARM_Limits",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active_Lease",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "As_Is",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BlockNum",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Buyer_Appraisal_Required",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Buyer_Inspection_Window",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Buyer_Loan_Application_Start",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Buyer_Title_Insurance",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Buyer_To_Pay_HW",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Buyer_To_Purchase_HW_Later",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Buyer_Waives_Lead_Paint_Inspection",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Buyer_Waves_Right_To_HW",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cash",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Closing_Window",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Closing_Window_Latest",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Closing_Window_Soonest",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClothesDryer",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClothesWasher",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Contingent_Addendum",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Contingent_On_Lead_Paint",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Contingent_On_Survey",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Conventional",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeedBook",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Delayed_Possession_Addendum",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DishWasher",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EMD",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EMD_With_ListingBroker",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EMD_With_SellingBroker",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FHA",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Fixed_Rate",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gift",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HOA_Addendum",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HW",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "HW_Price",
                table: "Contract",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ImageURLs",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Interest_Rate",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Keys_at_Closing",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Last_Best_Request_Window",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lead_Paint_Inspection_Window",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lender_Appraisal_Required",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "LineOfEquity",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ListAgent",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListAgentPhone",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListCompany",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Loan_Length",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LotNum",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Microwave",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MlsNumber",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "New_Construction_HW",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "No_Appraisal_Required",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "No_Lead_Paint",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Other",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Other_Addendum",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Other_Financing",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Other_Provisions",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Page",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Propane_Leased",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Propane_NotApplicable",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Propane_NotRemain",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Propane_Owned",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Propane_Will_Remain",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Purchase_Price",
                table: "Contract",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Refrigerator",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Seller_Disclosure_Recieved",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Seller_Lead_Paint_Response_Window",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seller_Repair_Request_Response_Window",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Seller_To_Pay_HW",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StoveRange",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubLotNum",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VA",
                table: "Contract",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
