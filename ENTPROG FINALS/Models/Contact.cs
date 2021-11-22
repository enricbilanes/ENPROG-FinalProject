using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ENTPROG_FINALS.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field.")]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Required Field.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Format.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Required Field.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Required Field.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Required Field.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
