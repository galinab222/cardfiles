using System.Data.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using CardFiles.Classes;


namespace CardFiles
{
    class UserContext: DbContext
    {
        public UserContext()
                   : base("DbConnectionString")
        { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }

       
    }
}

