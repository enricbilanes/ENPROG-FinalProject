using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ENTPROG_FINALS.Models
{
    public class Donation
    {
        [Key]
        public string DonationID { get; set; }

        public string Role { get; set; }
        
        //user changes

        public virtual User User { get; set; }
        public Guid? UserId { get; set; }

        [Required(ErrorMessage = "Required.")]
        public int DonationAmount { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Beneficiary { get; set; }

        [Display(Name = "Anonymous")]
        public DonationType Anonymous { get; set; }
    }

    public enum DonationType
    {
        Anonymous = 1,
        Visible = 2
    }
}

