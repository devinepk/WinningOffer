using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinningOffer.Models
{
    public class Appliance  //1 = remain, 2 = remove, 3 = n/a
    {
        [Key]
        public Guid Appliance_id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Refrigerator(s)")]
        public int Refrigerator { get; set; }

        [Display(Name = "Stove/Range(s)")]
        public int StoveRange { get; set; }

        [Display(Name = "Dish Washer")]
        public int DishWasher { get; set; }

        public int Microwave { get; set; }

        [Display(Name = "Clothes Washer")]
        public int ClothesWasher { get; set; }

        [Display(Name = "Clothes Dryer")]
        public int ClothesDryer { get; set; }

        public int Other { get; set; }
    }
}
