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
        public string Propane_Tank_Ownership { get; set; } // owned, leased

        [Display(Name = "Is the propane tank staying with the property?")]
        public string Propane_Tank_Status { get; set; } // stays, goes

        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public Contract Contract { get; set; }
        public Guid ContractId { get; set; }

    }
}
