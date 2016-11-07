using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DomainModel;

namespace MySqlDatabase
{
    public class MysqlDataContext : DbContext
    {
        public DbSet<Comments> Comment { get; set; }
        public DbSet<Posts> Post { get; set; }

        public IList<Tags> GetTags()
        {
            throw new NotImplementedException();  /* to be implemented*/
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>().ToTable("comments");
            modelBuilder.Entity<Comments>().Property(t => t.CommentId).HasColumnName("commentid");
            modelBuilder.Entity<Comments>().Property(t => t.PostId).HasColumnName("postid");
            modelBuilder.Entity<Comments>().Property(t => t.CommentScore).HasColumnName("commentscore");
            modelBuilder.Entity<Comments>().Property(t => t.CommentText).HasColumnName("commenttext");
            modelBuilder.Entity<Comments>().Property(t => t.CommentCeated).HasColumnName("commentcreatedate");
            modelBuilder.Entity<Comments>().Property(t => t.OwnerUserId).HasColumnName("owneruserid");

            modelBuilder.Entity<Posts>().ToTable("posts");
            modelBuilder.Entity<Posts>().Property(p => p.PostsId).HasColumnName("id");
            modelBuilder.Entity<Posts>().Property(p => p.PostTypeId).HasColumnName("posttypeid");
            modelBuilder.Entity<Posts>().Property(p => p.creationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Posts>().Property(p => p.Score).HasColumnName("score");
            modelBuilder.Entity<Posts>().Property(p => p.Body).HasColumnName("body");
            modelBuilder.Entity<Posts>().Property(p => p.OwnerUserId).HasColumnName("owneruserid");

            modelBuilder.Entity<Answers>().ToTable("answers");
            modelBuilder.Entity<Answers>().Property(a => a.AnswerId).HasColumnName("answerid");
            modelBuilder.Entity<Answers>().Property(a => a.PostId).HasColumnName("postid");
            modelBuilder.Entity<Answers>().Property(a => a.ParentId).HasColumnName("parentid");



            base.OnModelCreating(modelBuilder);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=project_portfolio1_stackoverflow; uid=root; pwd=root");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
