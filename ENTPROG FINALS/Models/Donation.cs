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

        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        [Display (Name = "Last Name")]
        public string LastName { get; set; }

        public Guid? UserId { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string DonationAmount { get; set; }

        [Required(ErrorMessage = "Required.")]
        public virtual Beneficiary Beneficiary { get; set; }

        [Display(Name = "Anonymous")]
        public DonationType Anonymous { get; set; }

        [Display(Name = "Anonymous")]
        public DateTime Date { get; set; }

        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }

    public enum DonationType
    {
        Anonymous = 1,
        Visible = 2
    }


}

