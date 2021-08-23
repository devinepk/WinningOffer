using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LightningOffer.Models
{
    public class Appraisal //1 = lender, 2 = buyer, 3 = n/a
    {
        [Key]
        public Guid Appraisal_id { get; set; }
        public DateTime CreatedDate { get; set; }


        [Display(Name = "(APPRAISAL REQUIRED) This transaction involves a lender's appraisal.")]
        public int Lender_Appraisal_Required { get; set; }

        [Display(Name = "(APPRAISAL REQUIRED) This is a cash, private financing, or contract for deed transaction.")]
        public int Buyer_Appraisal_Required { get; set; }

        [Display(Name = "(NO APPRAISAL REQUIRED) This is a cash, private financing, or contract for deed transaction")]
        public int No_Appraisal_Required { get; set; }

        public DateTime AppraisalCompletedBy { get; set; } 
        public Contract Contract { get; set; }

        public Guid ContractId { get; set; }

    }
}
