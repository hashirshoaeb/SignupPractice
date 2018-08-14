using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SignupPractice.Models
{
    public class projectguidancecommitteeEntity
    {
        public int id { get; set; }

        public int projectId { get; set; }

        public int supervisorId { get; set; }

        public int cosupervisor1Id { get; set; }

        public int cosupervisor2Id { get; set; }

        public int student1Id { get; set; }

        public int student2Id { get; set; }

        public int student3Id { get; set; }

        public int student4Id { get; set; }
    }

    public class projectguidancecommitteeEntityDBContext : DbContext
    {

    }
}