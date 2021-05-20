using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinningOffer.Models
{
    public class Person
    {
        [Key]
        public Guid Person_Id { get; set; }
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Listing Company")]
        public string ListCompany { get; set; }

        [Display(Name = "Listing Agent")]
        public string ListAgent { get; set; }

        [Display(Name = "Listing Agent Phone")]
        public string ListAgentPhone { get; set; }

    }
}
