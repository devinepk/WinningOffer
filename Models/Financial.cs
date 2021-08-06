using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LightningOffer.Models
{
    public class Financial
    {
        //Purchase price
        [Key]
        public Guid Financial_id { get; set; }

        public IdentityUser User { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        
        [Required(ErrorMessage ="The purchase price must be at least $30,000.")]
        [Display(Name = "Purchase Price")]
        [DataType(DataType.Currency)]
        public int Purchase_Price { get; set; }

        [Required(ErrorMessage = "This is required, please make a selection.")]
        [Display(Name = "Earnest Money Deposit")]
        public string EMD { get; set; } // will be radio options: $500, $1000, Other

        //Payment of purchase price 
        public string DownPaymentSource { get; set; }

        public string DownPaymentAmount { get; set; }


        public string DownPaymentFormat { get; set; }

        // Financing remaining section -- conventional, FHA, VA, ARM, Other
        public string LoanType { get; set; } // Conventional, FHA, VA, TODO: Other

        [Required(ErrorMessage = "This is required, please make a selection.")]
        [Display(Name = "Rate Type")]
        public string Rate_Type { get; set; } // Adjustable or fixed.  If Adjustable, show ARM Limits. If fixed, show

        [Required(ErrorMessage = "This is required, please make a selection.")]
        [Display(Name = "Loan Length (years)")] 
        public int Loan_Length { get; set; } // 15 or 30

        [Required]
        [Display(Name = "The interest rate will not exceed the following:")]
        public double Interest_Rate { get; set; }

        [Display(Name = "ARM Interest Rate Limit")]
        public int ARM_Limits { get; set; }

        [Required(ErrorMessage = "This is required, please make a selection.")]
        [Display(Name = "Has the buyer applied for the loan?")]
        public string Buyer_Loan_Application_Start { get; set; } // Radio: yes, they're preapproved (upload letter), no will apply within 7 days


        //Earnest Money Deposit
        [Required(ErrorMessage = "This is required, please make a selection.")]
        [Display(Name = "Listing Broker")]
        public bool EMD_With_ListingBroker { get; set; }

        [Required(ErrorMessage = "This is required, please make a selection.")]
        [Display(Name = "Selling Broker")]
        public bool EMD_With_SellingBroker { get; set; }

        public Contract Contract { get; set; }
        
        public Guid ContractId { get; set; }
    }
}
