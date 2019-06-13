using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ATMBankDAL.Models
{
    [Table("CardOwner")]
    public class CardOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public String FirstName{ get; set; }

        [Required, MaxLength(50)]
        public String LastName { get; set; }

        public virtual ISet<Card> Cards { get; set; } = new HashSet<Card>();
    }
}
