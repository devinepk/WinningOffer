using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinningOffer.Models
{
    public class Item
    {
        
        public int Id { get; set; }
        public bool Refrigerator { get; set; }

        [Display(Name = "Dish Washer")]
        public bool DishWasher { get; set; }

        [Display(Name = "Oven/Range")]
        public bool OvenRange { get; set; }

        [Display(Name = "Wall Oven")]
        public bool WallOven { get; set; }

        [Display(Name = "Clothes Washer")]
        public bool ClothesWasher { get; set; }

        [Display(Name = "Clothes Dryer")]
        public bool ClothesDryer { get; set; }
        public bool Microwave { get; set; }
        public string Other { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
