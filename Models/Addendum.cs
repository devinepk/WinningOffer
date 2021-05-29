using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LightningOffer.Models
{
    public class Addendum
    {
        [Key]
        public Guid Addendum_id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Display(Name = "HOA")]
        public bool HOA_Addendum { get; set; }

        [Display(Name = "Delayed Possession Agreement")]
        public bool Delayed_Possession_Addendum { get; set; }

        [Display(Name = "Contingent on Sale/Closing of Buyer's Property")]
        public bool Contingent_Addendum { get; set; }

        [Display(Name = "Other Addendum")]
        public bool Other_Addendum { get; set; }

    }
}
