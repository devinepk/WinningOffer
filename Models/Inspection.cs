using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinningOffer.Models
{
    public class Inspection
    {
        [Key]
        public Guid Inspection_id { get; set; }
        public DateTime CreatedDate { get; set; }
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
    }
}
