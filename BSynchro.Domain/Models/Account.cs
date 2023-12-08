using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Domain.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual  Customer Customer { get; set; }
        public decimal? Balance { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
