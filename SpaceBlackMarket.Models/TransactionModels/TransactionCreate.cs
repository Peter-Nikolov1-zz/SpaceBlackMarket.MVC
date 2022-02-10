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
        [Required]
        public int ItemId { get; set; }

        public virtual List<Item> Item { get; set; } // Make dropdown list in View
    }
}
