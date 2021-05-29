using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LightningOffer.Models
{
    public class Closing
    {
        [Key]
        public Guid Closing_id { get; set; }
        public DateTime CreatedDate { get; set; }

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
        public bool Buyer_Title_Insurance { get; set; }

        [Display(Name = "Other Provisions")]
        public string Other_Provisions { get; set; }
    }
}
