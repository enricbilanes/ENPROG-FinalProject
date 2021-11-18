using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ENTPROG_FINALS.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        public string Table { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string RecordID { get; set; }

        [Required(ErrorMessage = "Required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string User { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string TransactionMade { get; set; }

        [Display(Name = "Anonymous")]
        public DonationType Anonymous { get; set; }
    }
}
