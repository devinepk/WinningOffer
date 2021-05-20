using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinningOffer.Models
{
    public class Disclosure
    {
        [Key]
        public Guid Disclosure_id { get; set; }
        public DateTime CreatedDate { get; set; }
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

    }
}
