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
        public Guid ContractId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? BuyerSignedDate { get; set; }
        public DateTime? SellerSignedDate { get; set; }
        public DateTime? ListAgentSignedDate { get; set; }
        public DateTime? SellingAgentSignedDate { get; set; }
        public int PurchasePrice { get; set; }

        public bool IsActive { get; set; } // TODO: Mark this false in the Delete section of the controller.
        public Guid UserId { get; set; }

        // Add FK reference from AspNetUserTable

        public Property Property { get; set; }
        public Person Person { get; set; }
    }
}
