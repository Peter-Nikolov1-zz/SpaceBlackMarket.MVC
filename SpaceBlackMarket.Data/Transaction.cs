using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlackMarket.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        public double CreditsAmount { get; set; }        

    }
}