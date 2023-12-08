using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Domain.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        [ForeignKey("AccountID")]
        public Account Account { get; set; }

        public decimal Amount { get; set; }

        public DateTime Timestamp { get; set; } // Property to store the timestamp

    }
}
