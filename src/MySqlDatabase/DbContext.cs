using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlDatabase
{
    public class DbContext
    {

        public DbContext() : base("Linkpost")

        { 
}

        public DbSet<LinkPost > LinkPost { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        { 
modelBuilder.Entity<LinkPost>().ToTable("linkpost");
modelBuilder.Entity<LinkPost>().Property(lp => lp.PostId).HasColumnName("postid");
modelBuilder.Entity<LinkPost>().Property(lp => lp.LinkPostId).HasColumnName("linkpostid");

            base.OnModelCreating(modelBuilder);
        }
    }
}
