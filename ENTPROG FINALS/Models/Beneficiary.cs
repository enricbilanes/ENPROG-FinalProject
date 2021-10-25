using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ENTPROG_FINALS.Models
{
    public class Beneficiary
    {
        [Key]
        public string BeneficiaryID { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Beneficiaries { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Decsription { get; set; }

        [Required(ErrorMessage = "Required.")]
        public int DonationSummary { get; set; }

    }
}
