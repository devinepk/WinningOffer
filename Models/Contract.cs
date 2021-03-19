using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinningOffer.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Written Date")]
        [DataType(DataType.Date)]
        public DateTime WrittenDate { get; set; }
        public string Address { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Rating { get; set; }

    }
}
