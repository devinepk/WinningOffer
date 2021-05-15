using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinningOffer.Models
{
    public class Contract
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

        //people information
        [Display(Name = "Listing Company")]
        public string ListCompany { get; set; }

        [Display(Name = "Listing Agent")]
        public string ListAgent { get; set; }

        [Display(Name = "Listing Agent Phone")]
        public string ListAgentPhone { get; set; }

        [Display(Name = "MLS Number")]
        public string MlsNumber { get; set; }


        //property section
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public string PostalCode { get; set; }

        public string Country { get; set; }

      
        //parcel information
        public string DeedBook { get; set; }
        public string Page { get; set; }
        public string BlockNum { get; set; }
        public string LotNum { get; set; }
        public string SubLotNum { get; set; }
        public string County { get; set; }

        //Appliances section: 1 = remain (checked), 2 = null, 3 = remove
        [Display(Name = "Refrigerator(s)")]
        public int Refrigerator { get; set; }

        [Display(Name = "Stove/Range(s)")]
        public int StoveRange { get; set; }

        [Display(Name = "Dish Washer")]
        public int DishWasher { get; set; }

        public int Microwave { get; set; }

        [Display(Name = "Clothes Washer")]
        public int ClothesWasher { get; set; }

        [Display(Name = "Clothes Dryer")]
        public int ClothesDryer { get; set; }

        public int Other { get; set; }

        //Fuel/propane section
        [Display(Name = "Tank is owned")]
        public bool Propane_Owned { get; set; }

        [Display(Name = "Tank is leased")]
        public bool Propane_Leased { get; set; }

        [Display(Name = "Tank will remain")]
        public bool Propane_Will_Remain { get; set; }

        [Display(Name = "Tank will NOT remain")]
        public bool Propane_NotRemain { get; set; }

        [Display(Name = "N/A - Does not apply")]
        public bool Propane_NotApplicable { get; set; }


        //Purchase price
        [Display(Name = "Purchase Price")]
        public float Purchase_Price { get; set; }

        [Display(Name = "Earnest Money Deposit")]
        public int EMD { get; set; }

        //Payment of purchase price 
        public bool Cash { get; set; } //if selected, prompt for dollar amount or percentage

        [Display(Name = "Equity Line")]
        public bool LineOfEquity { get; set; }

        public bool Gift { get; set; }

        [Display(Name = "Other Financing")]
        public bool Other_Financing { get; set; }

        //Financing remaining section
        public bool Conventional { get; set; }

        public bool FHA { get; set; }

        public bool VA { get; set; }

        [Display(Name ="Fixed Rate")]
        public bool Fixed_Rate { get; set; }

        [Display(Name = "Loan Length (years)")]
        public int Loan_Length { get; set; }

        [Display(Name = "Interest Rate Not to Exceed")]
        public int Interest_Rate { get; set; }

        [Display(Name = "ARM Limits")]
        public int ARM_Limits { get; set; }

        [Display(Name = "How soon will the buyer apply for the loan?")]
        public string Buyer_Loan_Application_Start { get; set; } // if "0", change to "Done"

        //TODO: lender contact info

        //Earnest Money Deposit
        [Display(Name = "Listing Broker")]
        public bool EMD_With_ListingBroker { get; set; }

        [Display(Name = "Selling Broker")]
        public bool EMD_With_SellingBroker { get; set; }

        //
        //APPRAISAL (1 = lender, 2 = buyer, 3 = n/a
        //

        [Display(Name = "This transaction involves a lender")]
        public int Lender_Appraisal_Required { get; set; }

        [Display(Name = "This is a cash, private financing, or contract for deed transaction")]
        public int Buyer_Appraisal_Required { get; set; }

        [Display(Name = "This is a cash, private financing, or contract for deed transaction")]
        public int No_Appraisal_Required { get; set; }

        //Home Warranty

        [Display(Name = "Home Warranty")]
        public bool HW { get; set; }

        [Display(Name = "Home Warranty Price")]
        public double HW_Price { get; set; }

        [Display(Name = "Buyer Pays for Home Warranty")]
        public bool Seller_To_Pay_HW { get; set; }

        [Display(Name = "Seller Pays for Home Warranty")]
        public bool Buyer_To_Pay_HW { get; set; }

        [Display(Name = "New Construction")]
        public bool New_Construction_HW { get; set; }

        [Display(Name = "Buyer Waves Right to Purchase Home Warranty")]
        public bool Buyer_Waves_Right_To_HW { get; set; }

        [Display(Name = "Buyer Reserves Right to Purchase Home Warranty Later")]
        public bool Buyer_To_Purchase_HW_Later { get; set; }


        //Sellers Disclosure
        [Display(Name = "Buyer acknowledges receipt of Seller Disclosure Form")]
        public bool Seller_Disclosure_Recieved { get; set; }

        //Lead paint disclosure
        [Display(Name = "This property was not built rpior to 1978")]
        public bool No_Lead_Paint { get; set; }

        [Display(Name = "Buyer waives right to lead paint inspection")]
        public bool Buyer_Waives_Lead_Paint_Inspection { get; set; }

        [Display(Name = "Contract is continent on lead paint inspection")]
        public bool Contingent_On_Lead_Paint { get; set; }

        [Display(Name = "Lead Paint Inspection Window")]
        public int Lead_Paint_Inspection_Window { get; set; }

        [Display(Name = "Seller Lead Paint Response Window")]
        public int Seller_Lead_Paint_Response_Window { get; set; }

        //Inspections
        [Display(Name = "Buyer accepts as-is")]
        public bool As_Is { get; set; }

        [Display(Name = "Buyer Inspection Window")]
        public int Buyer_Inspection_Window { get; set; }

        [Display(Name = "Seller Repair Request Response Window")]
        public int Seller_Repair_Request_Response_Window { get; set; }

        [Display(Name = "Last, best, and final repair request window")]
        public int Last_Best_Request_Window { get; set; }

        //Survey
        [Display(Name = "Is this contract contingent on a survey?")]
        public bool Contingent_On_Survey { get; set; }

        //Closing
        [Display(Name = "A specific closing date")]
        public DateTime Specific_Closing_Date { get; set; }

        [Display(Name = "A closing window")]
        public bool Closing_Window { get; set; }

        [Display(Name = "No sooner than")]
        public int Closing_Window_Soonest { get; set; }

        [Display(Name = "No later than")]
        public bool Closing_Window_Latest { get; set; }


        //Possession
        [Display(Name = "Keys at closing")]
        public bool Keys_at_Closing { get; set; }

        [Display(Name = "After closing")]
        public DateTime Keys_after_Closing { get; set; }

        //Leases
        [Display(Name = "Is there an active lease on the property?")]
        public bool Active_Lease { get; set; }

        //Title protection
        [Display(Name = "Does buyer want Owner's Title Insurance?")]
        public bool Buyer_Title_Insurance{ get; set; }

        [Display(Name = "Other Provisions")]
        public string Other_Provisions { get; set; }

        //Addendums
        [Display(Name = "HOA")]
        public bool HOA_Addendum { get; set; }

        [Display(Name = "Delayed Possession Agreement")]
        public bool Delayed_Possession_Addendum { get; set; }

        [Display(Name = "Contingent on Sale/Closing of Buyer's Property")]
        public bool Contingent_Addendum { get; set; }

        [Display(Name = "Other Addendum")]
        public bool Other_Addendum { get; set; }

        public string ImageURLs { get; set; }


    }
}
