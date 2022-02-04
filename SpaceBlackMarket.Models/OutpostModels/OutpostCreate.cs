using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.OutpostModels
{
    public class OutpostCreate
    {
        [Required]
        [MaxLength(20, ErrorMessage = "There is no way the name is that long...")]
        [MinLength(2, ErrorMessage = "There has to be a longer name...")]
        [Display(Name = "Outpost Name?")]
        public string OutpostName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "First ever galaxy to have a longer than 50 character name...")]
        [MinLength(3, ErrorMessage = "Gonna have to be longer than that.")]
        [Display(Name = "Galaxy Name?")]
        public string GalaxyName { get; set; }

        [Required]
        [Display(Name = "Example: RA 0h 42m 44s | Dec +41 16 9")]
        public string SystemCoordinates { get; set; }

        [Required]
        [Display(Name = "Please select a danger level")]
        public DangerLevel DangerLevel { get; set; } // Associate with string... 1 = "Not Terribly Dangerous" ... 5 = "DO NOT COME WITHOUT A WEAPON"
    }
}
