using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinningOffer.Models
{
    public class Item
    {
        
        public int Id { get; set; }
        public bool Refrigerator { get; set; }
        public bool DishWasher { get; set; }
        public bool OvenRange { get; set; }
        public bool WallOven { get; set; }
        public bool ClothesWasher { get; set; }
        public bool ClothesDryer { get; set; }
        public bool Microwave { get; set; }
        public string Other { get; set; }

    }
}
