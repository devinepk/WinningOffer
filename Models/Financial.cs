using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LightningOffer.Models
{
    public class Financial
    {
        //Purchase price
        [Key]
        public Guid Financial_id { get; set; }
        public DateTime CreatedDate { get; set; }
        
        [Display(Name = "Purchase Price")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public int Purchase_Price { get; set; }

        [Display(Name = "Earnest Money Deposit")]
        public string EMD { get; set; } // will be radio options: $500, $1000, Other

        //Payment of purchase price 
        public bool Cash { get; set; } //if selected, prompt for dollar amount or percentage

        [Display(Name = "Equity Line")]
        public bool LineOfEquity { get; set; }

        public bool Gift { get; set; }

        [Display(Name = "Financing")]
        public bool Other_Financing { get; set; }

        //Financing remaining section
        public bool Conventional { get; set; }

        public bool FHA { get; set; }

        public bool VA { get; set; }

        [Display(Name = "Fixed Rate")]
        public bool Fixed_Rate { get; set; }

        [Display(Name = "Loan Length (years)")]
        public int Loan_Length { get; set; }

        [Display(Name = "Interest Rate Not to Exceed")]
        public int Interest_Rate { get; set; }

        [Display(Name = "ARM Limits")]
        public int ARM_Limits { get; set; }

        [Display(Name = "How soon will the buyer apply for the loan?")]
        public string Buyer_Loan_Application_Start { get; set; } // if "0", change to "Done"


        //Earnest Money Deposit
        [Display(Name = "Listing Broker")]
        public bool EMD_With_ListingBroker { get; set; }

        [Display(Name = "Selling Broker")]
        public bool EMD_With_SellingBroker { get; set; }
    }
}
