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
        public string DownPaymentSource { get; set; } 

        public string DownPaymentAmount { get; set; }

        // Financing remaining section -- conventional, FHA, VA, ARM, Other
        public string LoanType { get; set; } // Conventional, FHA, VA, TODO: Other

        [Display(Name = "Rate Type")]
        public string Rate_Type { get; set; } // Adjustable or fixed.  If Adjustable, show ARM Limits. If fixed, show

        [Display(Name = "Loan Length (years)")] 
        public int Loan_Length { get; set; } // 15 or 30

        [Display(Name = "The interest rate will not exceed the following:")]
        public int Interest_Rate { get; set; }

        [Display(Name = "ARM Interest Rate Limit")]
        public int ARM_Limits { get; set; }

        [Display(Name = "Has the buyer applied for the loan?")]
        public string Buyer_Loan_Application_Start { get; set; } // Radio: yes, they're preapproved (upload letter), no will apply within 7 days


        //Earnest Money Deposit
        [Display(Name = "Listing Broker")]
        public bool EMD_With_ListingBroker { get; set; }

        [Display(Name = "Selling Broker")]
        public bool EMD_With_SellingBroker { get; set; }
    }
}
