using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ATMBankDAL.Models
{
    [Table("BankTransaction")]
    public class BankTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime ExecutionDate { get; set; }

        [Required]
        public bool IsSuccesful { get; set; }

        [Required]
        public int SenderCardId { get; set; }

        [Required]
        public int RecipientCardId { get; set; }

        [ForeignKey(nameof(SenderCardId))]
        public virtual Card SenderCard { get; set; }

        [ForeignKey(nameof(RecipientCardId))]
        public virtual Card RecipientCard { get; set; }
    }
}
