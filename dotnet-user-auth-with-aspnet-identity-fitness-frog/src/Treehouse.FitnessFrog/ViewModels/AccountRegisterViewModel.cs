﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Treehouse.FitnessFrog.ViewModels
{
    public class AccountRegisterViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(100, MinimumLength = 6, ErrorMessage = "The {0} must be at least {2} characters long, and no more than {1} characters long.")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required, Compare("Password", ErrorMessage = "Sorry, your passwords don't match.")]
        public string ConfirmPassword { get; set; }
    }
}