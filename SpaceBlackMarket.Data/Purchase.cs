using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Data
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        [Required]
        public double PurchaseTotal { get; set; }

        [Required]
        public DateTimeOffset PurchaseDate { get; set; }
    }
}
