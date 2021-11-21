using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ENTPROG_FINALS.Models;
using System.ComponentModel.DataAnnotations;

namespace ENTPROG_FINALS.Models
{
    public class Donation
    {
        [Key]
        public int DonationID { get; set; }

        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid? UserId { get; set; }

        [Required(ErrorMessage = "Required.")]
        public int DonationAmount { get; set; }

        [Required(ErrorMessage = "Required.")]
        public virtual Beneficiary Beneficiary { get; set; }

        [Display(Name = "Anonymous")]
        public DonationType Anonymous { get; set; }
    }

    public enum DonationType
    {
        Anonymous = 1,
        Visible = 2
    }


}

