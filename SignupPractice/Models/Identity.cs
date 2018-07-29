using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SignupPractice.Models
{
    public class Identity
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public long phone { get; set; }
    }

    public class IdentityDBContext : DbContext
    {
        public DbSet<Identity> Identies { get; set; }

        public bool identitycheck(string c_email, string c_password)
        {
            //var myIdentity = from e in Identies where e.email == c_email select e;
            foreach(Identity i in Identies)
            {
                if (i.email == c_email && i.password == c_password)
                    return true;
            }
            return false;
        }
    }
}