using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.ItemModels
{
    public class ItemCreate
    {
        [Display(Name = "Who is making this?")]
        public int SpaceTravelerProfileId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter a longer name.")]
        [MaxLength(20, ErrorMessage = "There's no way its that long of a name...")]
        [Display(Name = "What is this item called?")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Item Type?")]
        public ItemType Type { get; set; } // This will be a drop down list, display and min/max length not required.

        [Required]
        [MaxLength(150, ErrorMessage = "Please use shorter description.")]
        [MinLength(10, ErrorMessage = "Please enter more.")]
        [Display(Name = "Enter a description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Credit Cost:")]
        public double Price { get; set; }
    }
}
