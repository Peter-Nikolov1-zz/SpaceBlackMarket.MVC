using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.PurchaseModels
{
    public class PurchaseItem
    {
        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public double ItemPrice { get; set; }

    }
}
