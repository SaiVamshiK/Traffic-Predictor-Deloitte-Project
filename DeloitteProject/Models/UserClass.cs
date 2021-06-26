using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteProject.Models
{
    public class UserClass
    {
        [Required(ErrorMessage ="Enter the email")]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter the Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string pwd { get; set; }
        [Required(ErrorMessage = "Enter the Password field again")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("pwd")]
        public string ConfirmPwd { get; set; }
    }
}
