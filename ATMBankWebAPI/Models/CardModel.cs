using ATMBankDAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATMBankWebAPI.Models
{
    public class CardModel
    {
        public int Id { get; set; }

        [CreditCard]
        public String Number { get; set; }

        [Range(0, 9999999999.99)]
        public decimal Balance { get; set; }

        [Required]
        public CardOwnerModel Owner { get; set; }

    }
}
