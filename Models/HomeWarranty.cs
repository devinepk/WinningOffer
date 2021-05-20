using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinningOffer.Models
{
    public class HomeWarranty
    {
        [Key]
        public Guid HomeWarranty_id { get; set; }
        public DateTime CreatedDate { get; set; }
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

    }
}
