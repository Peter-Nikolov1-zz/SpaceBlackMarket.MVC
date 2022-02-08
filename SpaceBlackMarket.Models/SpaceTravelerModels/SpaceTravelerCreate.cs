using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.SpaceTravelerModels
{
    public class SpaceTravelerCreate
    {
        [Required]
        [MaxLength(20,ErrorMessage = "What kind of a name is that? SHORTER!")]
        [MinLength(4, ErrorMessage = "Gotta be more than that")]
        [Display(Name = "What do you go by?")]
        public string TravelerAlias { get; set; }

        [Required]
        [Display(Name = "How much trouble are you in?")]
        public WantedLevel WantedLevel { get; set; }

        [Required]
        [Display(Name = "Do you work with others?")]
        public bool WillingToCooperate { get; set; }

        [Required]
        [Display(Name = "How many credits do you have?")]
        public double Credits { get; set; }
    }
}
