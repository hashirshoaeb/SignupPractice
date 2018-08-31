using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SignupPractice.Models
{
    public class TeacherEntity
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public string designation { get; set; }

        //public string specification { get; set; }
        //public string personalinfo { get; set; }

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

    public class TeacherEntityDBContext : DbContext
    {
        public DbSet<TeacherEntity> teacherEntities { get; set; }

        public int? identitycheck(string c_email, string c_password, out TeacherEntity teacherEntity)
        {
            teacherEntity = null;
            if (null != (teacherEntity = teacherEntities.SingleOrDefault(x => x.email == c_email))) //email verified
            {
                if (teacherEntity.password == c_password) // password varified
                    return teacherEntity.id;
                return null;
            }
            return null;
        }
    }

}