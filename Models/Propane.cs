using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinningOffer.Models
{
    public class Propane
    {
       public int Id { get; set; }

        [Display(Name = "Tank is owned")]
        public bool Owned { get; set; }

        [Display(Name = "Tank is leased")]
        public bool Leased { get; set; }

        [Display(Name = "Tank will remain")]
        public bool WillRemain { get; set; }

        [Display(Name = "Tank will NOT remain")]
        public bool NotRemain { get; set; }

        [Display(Name = "N/A - Does not apply")]
        public bool NotApplication { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
