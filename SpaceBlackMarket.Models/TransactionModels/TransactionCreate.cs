using SpaceBlackMarket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.TransactionModels
{
    public class TransactionCreate
    {
        [Display(Name = "Item ID")]
        public int ItemId { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime DateOfPurchase { get; set; }

        public double CreditsAmount { get; set; }

        [Required]
        [Display(Name = "Item")]
        public string SelectItems { get; set; }
        public IEnumerable<Item> Item { get; set; } // Make dropdown list in View
    }
}
