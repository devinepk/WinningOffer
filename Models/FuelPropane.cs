using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LightningOffer.Models
{
    public class FuelPropane 
    {
        [Key]
        public Guid FuelPropane_id { get; set; }
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Is the propane tank owned or leased?")]
        public int Propane_Tank_Ownership { get; set; } // 1 = owned, 2 = leased

        [Display(Name = "Is the propane tank staying with the property?")]
        public int Propane_Tank_Status { get; set; } // 1 = Yes it stays, 2 = No it goes

        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public Contract Contract { get; set; }
        public Guid ContractId { get; set; }

    }
}
