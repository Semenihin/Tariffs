using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pcar21.Models
{
    public class Pcar21Context : DbContext
    {
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Output> Outputs { get; set; } 
    }

    public class Pcar21DbInitializer : DropCreateDatabaseAlways<Pcar21Context>
    {
        protected override void Seed(Pcar21Context context)
        {
            base.Seed(context);
        }
    }
}
