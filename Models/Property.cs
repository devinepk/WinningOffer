using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinningOffer.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        public string DateAdded { get; set; }
        public string DateUpdated { get; set; }
        public string GeoLocation { get; set; }
        public string ImageURLs { get; set; }

        [Display(Name = "MLS Number")]
        public string MlsNumber { get; set; }

        [Display(Name = "No. of Bathrooms")]
        public int NumBathroom { get; set; }

        [Display(Name = "No. of Bedrooms")]
        public int NumBedroom { get; set; }

        [Display(Name = "List Price")]
        [Column(TypeName = "decimal(18,2)")]
        public int Price { get; set; }            
        public string SourceURLs { get; set; }

        [Display(Name = "Listing Agent")]
        public string Agent { get; set; }

        [Display(Name = "Listing Broker")]
        public string Company { get; set; }

        [Display(Name = "Agent Phone")]
        public int Phone { get; set; }
 
    }
}
