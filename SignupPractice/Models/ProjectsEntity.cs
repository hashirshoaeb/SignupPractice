using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SignupPractice.Models
{
    public class ProjectsEntity
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Field")]
        public string field { get; set; }

        [Display(Name = "Date of creation")]
        public string dateofcreation { get; set; }

        [Display(Name = "Deadline")]
        public string deadline { get; set; }

        public string teacher_id { get; set; }

        [Display(Name = "Progress")]
        public int progress { get; set; }
    }

    public class ProjectsEntityDBContext : DbContext
    {
        public DbSet<ProjectsEntity> projectsEntities { get; set; }
    }
}