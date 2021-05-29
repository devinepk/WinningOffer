using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LightningOffer.Models
{
    public class Property
    {
        [Key]
        public Guid Property_id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Display(Name = "MLS Number")]
        public string MlsNumber { get; set; }

        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public string PostalCode { get; set; }

        public string Country { get; set; }


        //parcel information
        public string DeedBook { get; set; }

        public string Page { get; set; }

        public string BlockNum { get; set; }

        public string LotNum { get; set; }

        public string SubLotNum { get; set; }

        public string County { get; set; }

        public string ImageURLs { get; set; }
    }
}
