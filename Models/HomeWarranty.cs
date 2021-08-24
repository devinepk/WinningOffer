using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LightningOffer.Models
{
    public class HomeWarranty
    {
        [Key]
        public Guid HomeWarranty_id { get; set; }
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Is the seller paying anything towards a home warranty?")]
        public string Who_Pays { get; set; } //buyer or seller. if Seller, ask how much. If buyer, make price null.

        public string who_chooses { get; set; } //

        [Display(Name = "Home Warranty Price")]
        public double Price { get; set; }

        public string Buyer_Final_Options { get; set; } //buyerAgreesToPurchase, propertyIsNewConstruction, buyerWaivesRight, buyerReservesRight

        public Contract Contract { get; set; }
        public Guid ContractId { get; set; }


    }
}
