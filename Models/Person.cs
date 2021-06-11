using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LightningOffer.Models
{
    public class Person
    {
        [Key]
        public Guid Person_Id { get; set; }
        public DateTime ? CreatedDate { get; set; }

        [Display(Name = "Listing Company")]
        public string ListCompany { get; set; }

        [Display(Name = "Listing Agent")]
        public string ListAgent { get; set; }

        [Display(Name = "Listing Agent Phone")]
        public string ListAgentPhone { get; set; }

        public Contract Contract { get; set; }
        public Guid ContractId { get; set; }

    }
}
