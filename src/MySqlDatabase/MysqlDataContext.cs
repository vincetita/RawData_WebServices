using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace MySqlDatabase
{
    public class MysqlDataContext : DbContext
    {
        public DbSet<Questions> Question { get; set; }
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questions>().ToTable("questions");
            modelBuilder.Entity<Questions>().Property(q => q.QuestionId).HasColumnName("questionid");
            modelBuilder.Entity<Questions>().Property(q => q.PostId).HasColumnName("postid");
            modelBuilder.Entity<Questions>().Property(q => q.Title).HasColumnName("title");
            modelBuilder.Entity<Questions>().Property(q => q.AcceptedAnswerId).HasColumnName("acceptedanswerid");
            modelBuilder.Entity<Questions>().Property(q => q.ClosedDate).HasColumnName("closeddate");


            modelBuilder.Entity<History>().ToTable("history");
            modelBuilder.Entity<History>().Property(h => h.HistoryId).HasColumnName("id");
            modelBuilder.Entity<History>().Property(h => h.Keyword).HasColumnName("keyword");
            modelBuilder.Entity<History>().Property(h => h.SearchDate).HasColumnName("searchdate");


            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=project_portfolio1_stackoverflow; uid=root; pwd=root");
            base.OnConfiguring(optionsBuilder);
        }
    }
}