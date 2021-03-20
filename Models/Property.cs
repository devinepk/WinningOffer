using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinningOffer.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Display(Name = "Street Address")]
        public string address { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "Zip Code")]
        public string postalCode { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }

        public string dateAdded { get; set; }
        public string dateUpdated { get; set; }
        public string geoLocation { get; set; }
        public string imageURLs { get; set; }

        [Display(Name = "MLS Number")]
        public string mlsNumber { get; set; }

        [Display(Name = "No. of Bathrooms")]
        public int numBathroom { get; set; }

        [Display(Name = "No. of Bedrooms")]
        public int numBedroom { get; set; }

        [Display(Name = "List Price")]
        [Column(TypeName = "decimal(18,2)")]
        public int price { get; set; }            
        public string sourceURLs { get; set; }

        [Display(Name = "Listing Agent")]
        public string agent { get; set; }

        [Display(Name = "Listing Broker")]
        public string company { get; set; }

        [Display(Name = "Agent Phone")]
        public int phone { get; set; }
 
    }
}
