using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ATMBankDAL.Models
{
    [Table("Card")]
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(16)]
        public String Number { get; set; }

        [Required, MaxLength(50)]
        public String EncodedPin { get; set; }

        [Required, MaxLength(50)]
        public decimal Balance { get; set; }

        public int OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual CardOwner Owner { get; set; }

        public virtual ISet<BankTransaction> SentTransactions { get; set; } = new HashSet<BankTransaction>();

        public virtual ISet<BankTransaction> ReceivedTransactions { get; set; } = new HashSet<BankTransaction>();

    }
}
