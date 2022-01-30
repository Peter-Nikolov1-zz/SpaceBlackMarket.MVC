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
        [Display(Name = "What do they go by?")]
        public string TravelerAlias { get; set; }

        [Required]
        [Display(Name = "How much trouble is this person in?")]
        public WantedLevel WantedLevel { get; set; }

        [Required]
        [Display(Name = "Do they work with others?")]
        public bool WillingToCooperate { get; set; }

        [Required]
        [Display(Name = "How many credits do they have?")]
        public double Credits { get; set; }
    }
}
