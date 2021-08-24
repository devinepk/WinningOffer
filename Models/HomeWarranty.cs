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


        [Display(Name = "Home Warranty Price")]
        public double Price { get; set; }

        [Display(Name = "New Construction")]
        public bool New_Construction_HW { get; set; }

        [Display(Name = "Buyer Waves Right to Purchase Home Warranty")]
        public bool Buyer_Waves_Right_To_HW { get; set; }

        [Display(Name = "Buyer Reserves Right to Purchase Home Warranty Later")]
        public bool Buyer_To_Purchase_HW_Later { get; set; }

        public Contract Contract { get; set; }
        public Guid ContractId { get; set; }


    }
}
