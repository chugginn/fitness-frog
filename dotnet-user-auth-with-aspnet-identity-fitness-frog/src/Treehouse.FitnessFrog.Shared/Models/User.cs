﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace Treehouse.FitnessFrog.Shared.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
