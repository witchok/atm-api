using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATMBankWebAPI.Models
{
    public class TransactionModel
    {
        [Required]
        [Range(0, 9999999.99)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime ExecutionDate { get; set; }

        [Required]
        public bool IsSuccesful { get; set; }

        [CreditCard]
        public string SenderCardNumber { get; set; }

        [CreditCard]
        public string RecipientCardNumber { get; set; }

    }
}
