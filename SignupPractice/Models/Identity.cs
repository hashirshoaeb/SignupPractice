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