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
        [Display (Name = "ID")]
        public int BeneficiaryID { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Beneficiaries { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Description { get; set; }

        [Display (Name = "Donation Summary")]
        [Required(ErrorMessage = "Required.")]
        public string DonationSummary { get; set; }

        [Display (Name = "Contact No.")]
        [Required(ErrorMessage = "Required.")]
        public string ContacNo { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Address { get; set; }
    }
}
