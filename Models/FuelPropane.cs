using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinningOffer.Models
{
    public class FuelPropane
    {
        [Key]
        public Guid FuelPropane_id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Tank is owned")]
        public bool Propane_Owned { get; set; }

        [Display(Name = "Tank is leased")]
        public bool Propane_Leased { get; set; }

        [Display(Name = "Tank will remain")]
        public bool Propane_Will_Remain { get; set; }

        [Display(Name = "Tank will NOT remain")]
        public bool Propane_NotRemain { get; set; }

        [Display(Name = "N/A - Does not apply")]
        public bool Propane_NotApplicable { get; set; }
    }
}
