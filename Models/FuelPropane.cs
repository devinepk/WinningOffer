using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LightningOffer.Models
{
    public class FuelPropane //1 = stays, 2 = goes, 3 = n/a, 4 = owned, 5 = leased
    {
        [Key]
        public Guid FuelPropane_id { get; set; }
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Is the propane tank owned or leased?")]
        public bool Propane_Tank_Ownership { get; set; } // true = owned, false = leased

        [Display(Name = "Is the propane tank staying with the property?")]
        public bool Propane_Tank_Status { get; set; } //true = stays, false = goes
        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public Contract Contract { get; set; }
        public Guid ContractId { get; set; }

    }
}
