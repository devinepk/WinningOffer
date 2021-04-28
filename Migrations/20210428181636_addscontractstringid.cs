using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinningOffer.Migrations
{
    public partial class addscontractstringid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MlsNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeedBook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlockNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LotNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubLotNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refrigerator = table.Column<int>(type: "int", nullable: false),
                    StoveRange = table.Column<int>(type: "int", nullable: false),
                    DishWasher = table.Column<int>(type: "int", nullable: false),
                    Microwave = table.Column<int>(type: "int", nullable: false),
                    ClothesWasher = table.Column<int>(type: "int", nullable: false),
                    ClothesDryer = table.Column<int>(type: "int", nullable: false),
                    Other = table.Column<int>(type: "int", nullable: false),
                    Propane_Owned = table.Column<bool>(type: "bit", nullable: false),
                    Propane_Leased = table.Column<bool>(type: "bit", nullable: false),
                    Propane_Will_Remain = table.Column<bool>(type: "bit", nullable: false),
                    Propane_NotRemain = table.Column<bool>(type: "bit", nullable: false),
                    Propane_NotApplicable = table.Column<bool>(type: "bit", nullable: false),
                    Purchase_Price = table.Column<float>(type: "real", nullable: false),
                    EMD = table.Column<int>(type: "int", nullable: false),
                    Cash = table.Column<bool>(type: "bit", nullable: false),
                    LineOfEquity = table.Column<bool>(type: "bit", nullable: false),
                    Gift = table.Column<bool>(type: "bit", nullable: false),
                    Other_Financing = table.Column<bool>(type: "bit", nullable: false),
                    Conventional = table.Column<bool>(type: "bit", nullable: false),
                    FHA = table.Column<bool>(type: "bit", nullable: false),
                    VA = table.Column<bool>(type: "bit", nullable: false),
                    Fixed_Rate = table.Column<bool>(type: "bit", nullable: false),
                    Loan_Length = table.Column<int>(type: "int", nullable: false),
                    Interest_Rate = table.Column<int>(type: "int", nullable: false),
                    ARM_Limits = table.Column<int>(type: "int", nullable: false),
                    Buyer_Loan_Application_Start = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMD_With_ListingBroker = table.Column<bool>(type: "bit", nullable: false),
                    EMD_With_SellingBroker = table.Column<bool>(type: "bit", nullable: false),
                    Lender_Appraisal_Required = table.Column<int>(type: "int", nullable: false),
                    Buyer_Appraisal_Required = table.Column<int>(type: "int", nullable: false),
                    No_Appraisal_Required = table.Column<int>(type: "int", nullable: false),
                    HW = table.Column<bool>(type: "bit", nullable: false),
                    HW_Price = table.Column<double>(type: "float", nullable: false),
                    Seller_To_Pay_HW = table.Column<bool>(type: "bit", nullable: false),
                    Buyer_To_Pay_HW = table.Column<bool>(type: "bit", nullable: false),
                    New_Construction_HW = table.Column<bool>(type: "bit", nullable: false),
                    Buyer_Waves_Right_To_HW = table.Column<bool>(type: "bit", nullable: false),
                    Buyer_To_Purchase_HW_Later = table.Column<bool>(type: "bit", nullable: false),
                    Seller_Disclosure_Recieved = table.Column<bool>(type: "bit", nullable: false),
                    No_Lead_Paint = table.Column<bool>(type: "bit", nullable: false),
                    Buyer_Waives_Lead_Paint_Inspection = table.Column<bool>(type: "bit", nullable: false),
                    Contingent_On_Lead_Paint = table.Column<bool>(type: "bit", nullable: false),
                    Lead_Paint_Inspection_Window = table.Column<int>(type: "int", nullable: false),
                    Seller_Lead_Paint_Response_Window = table.Column<int>(type: "int", nullable: false),
                    As_Is = table.Column<bool>(type: "bit", nullable: false),
                    Buyer_Inspection_Window = table.Column<int>(type: "int", nullable: false),
                    Seller_Repair_Request_Response_Window = table.Column<int>(type: "int", nullable: false),
                    Last_Best_Request_Window = table.Column<int>(type: "int", nullable: false),
                    Contingent_On_Survey = table.Column<bool>(type: "bit", nullable: false),
                    Specific_Closing_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Closing_Window = table.Column<bool>(type: "bit", nullable: false),
                    Closing_Window_Soonest = table.Column<int>(type: "int", nullable: false),
                    Closing_Window_Latest = table.Column<bool>(type: "bit", nullable: false),
                    Keys_at_Closing = table.Column<bool>(type: "bit", nullable: false),
                    Keys_after_Closing = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active_Lease = table.Column<bool>(type: "bit", nullable: false),
                    Buyer_Title_Insurance = table.Column<bool>(type: "bit", nullable: false),
                    Other_Provisions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HOA_Addendum = table.Column<bool>(type: "bit", nullable: false),
                    Delayed_Possession_Addendum = table.Column<bool>(type: "bit", nullable: false),
                    Contingent_Addendum = table.Column<bool>(type: "bit", nullable: false),
                    Other_Addendum = table.Column<bool>(type: "bit", nullable: false),
                    ImageURLs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract");
        }
    }
}
