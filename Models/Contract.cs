using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LightningOffer.Models
{
    public class Contract
    {
        [Key]
        public Guid Contract_id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime BuyerSignedDate { get; set; }
        public DateTime SellerSignedDate { get; set; }
        public DateTime ListAgentSignedDate { get; set; }
        public DateTime SellingAgentSignedDate { get; set; }
        public int PurchasePrice { get; set; }

        [ForeignKey("AspNetUserID")]
        public string OwnerID { get; set; }

        /*
        //Foreign key references
        [ForeignKey("Person_id")]
        public Person Person { get; set; }    
        public Guid Person_id { get; set; }
        public Property Property_id { get; set; }
        public Appliance Appliance_id { get; set; }
        public FuelPropane FuelPropane_id { get; set; }
        public Financial Financial_id { get; set; }
        public Appraisal Appraisal_id { get; set; }
        public HomeWarranty HomeWarranty_id { get; set; }
        public Disclosure Disclosure_id { get; set; }
        public Inspection Inspection_id { get; set; }
        public Closing Closing_id { get; set; }
        public Addendum Addendum_id { get; set; }
        */

    }
}
