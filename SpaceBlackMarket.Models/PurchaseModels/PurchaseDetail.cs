using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Models.PurchaseModels
{
    public class PurchaseDetail
    {
        public int PurchaseId { get; set; }

        [Display(Name = "Item Purchased")]
        public string ItemName { get; set; }

        [Display(Name = "Purchase Total")]
        public double PurchaseTotal { get; set; }
    }
}
