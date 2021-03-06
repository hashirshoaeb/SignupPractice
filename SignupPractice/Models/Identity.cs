﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SignupPractice.Models
{
    public class Identity
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "Password should be stronger up to 6 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
    }

    public class IdentityDBContext : DbContext
    {
        public DbSet<Identity> Identies { get; set; }

        public int? identitycheck(string c_email, string c_password, out Identity identity)
        {
            identity = null;
            if( null != (identity = Identies.SingleOrDefault(x => x.email == c_email))) //email verified
            {
                if (identity.password == c_password) // password varified
                    return identity.id;
                return null;
            }
            return null;
        }
    }
}