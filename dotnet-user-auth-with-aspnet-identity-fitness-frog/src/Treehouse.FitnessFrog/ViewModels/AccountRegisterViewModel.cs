using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Treehouse.FitnessFrog.ViewModels
{
    public class AccountRegisterViewModel
    {
        [StringLength(100, ErrorMessage = "Your {0} cannot be more than {1} characters long.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(100, ErrorMessage = "Your {0} cannot be more than {1} characters long.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(100, MinimumLength = 6, ErrorMessage = "The {0} must be at least {2} characters long, and no more than {1} characters long.")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required, Compare("Password", ErrorMessage = "Sorry, your passwords don't match.")]
        public string ConfirmPassword { get; set; }
    }
}