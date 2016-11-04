using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlDatabase
{
    public class MySqlDBContext  : DbContext
    {
        public DbSet<LinkPosts> LinkPost { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkPosts>().ToTable("linkposts");
            //modelBuilder.Entity<LinkPosts>().Property(t => t.PostId).HasColumnName("id");


            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=sakila;uid=root;pwd=12345Mail");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
