using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.PurchaseModels
{
    public class PurchaseList
    {
        [Display(Name = "Purchase Id")]
        public int PurchaseId { get; set; }

        [Display(Name = "Purchase Total")]
        public double PurchaseTotal { get; set; }

        [Display(Name = "Date of Purchase")]
        public DateTimeOffset PurchaseDate { get; set; }
    }
}
