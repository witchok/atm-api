using System;
using System.ComponentModel.DataAnnotations;

namespace ATMBankWebAPI.Models
{
    public class CardOwnerModel
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }
    }
}