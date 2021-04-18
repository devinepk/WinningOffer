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

        public string ImageURLs { get; set; }

        [Display(Name = "MLS Number")]
        public string MlsNumber { get; set; }

        [Display(Name = "List Price")]
        [Column(TypeName = "decimal(18,2)")]
        public int Price { get; set; }            
        public string SourceURLs { get; set; }

        [Display(Name = "Listing Agent")]
        public string ListingAgent { get; set; }

        [Display(Name = "Listing Broker")]
        public string ListingCompany { get; set; }

        [Display(Name = "Agent Phone")]
        public string ListingAgentPhone { get; set; }

        //parcel information
        public string DeedBook { get; set; }
        public string Page { get; set; }
        public string BlockNum { get; set; }
        public string LotNum { get; set; }
        public string SubLotNum { get; set; }
        public string County { get; set; }

    }
}
