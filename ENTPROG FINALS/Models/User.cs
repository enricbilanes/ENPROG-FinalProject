using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENTPROG_FINALS.Models
{
    public class User : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string PassWord { get; set; }

        [Display(Name = "Role Type")]
        public RoleType RoleSetting { get; set; }

    }

    public enum RoleType
    {
        User = 1,
        Admin = 2
    }
}
