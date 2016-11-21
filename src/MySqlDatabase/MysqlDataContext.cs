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
        public DbSet<PostAnswer> PostAnswer { get; set; }
        public DbSet<Answers> Answer { get; set; }
        public DbSet<Questions> Question { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<OwnComments> OwnComment { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<CombinedUsers> CombineUsers { get; set; }
        public DbSet<SearchKeywordStoredProc> SearchKeyordStoredProc { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchKeywordStoredProc>().HasKey(t => t.Id);

            modelBuilder.Entity<Comments>().ToTable("comments");
            modelBuilder.Entity<Comments>().Property(t => t.CommentId).HasColumnName("commentid");
            //modelBuilder.Entity<Comments>().HasKey(k => k.CommentId);                               // AnOther way of defining primary key in linq then data annotation
            modelBuilder.Entity<Comments>().Property(t => t.PostId).HasColumnName("postid");
            modelBuilder.Entity<Comments>().Property(t => t.CommentScore).HasColumnName("commentscore");
            modelBuilder.Entity<Comments>().Property(t => t.CommentText).HasColumnName("commenttext");
            modelBuilder.Entity<Comments>().Property(t => t.CommentCeated).HasColumnName("commentcreatedate");
            modelBuilder.Entity<Comments>().Property(t => t.OwnerUserId).HasColumnName("owneruserid");

         

            modelBuilder.Entity<Posts>().ToTable("posts");
            modelBuilder.Entity<Posts>().Property(p => p.PostsId).HasColumnName("id");
            //modelBuilder.Entity<Posts>().HasKey(p => p.PostsId);
            modelBuilder.Entity<Posts>().Property(p => p.PostTypeId).HasColumnName("posttypeid");
            modelBuilder.Entity<Posts>().Property(p => p.creationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Posts>().Property(p => p.Score).HasColumnName("score");
            modelBuilder.Entity<Posts>().Property(p => p.Body).HasColumnName("body");
            modelBuilder.Entity<Posts>().Property(p => p.OwnerUserId).HasColumnName("owneruserid");

            modelBuilder.Entity<Questions>().ToTable("questions");
            modelBuilder.Entity<Questions>().Property(q => q.QuestionId).HasColumnName("questionid");
            //modelBuilder.Entity<Questions>().HasKey(q => q.QuestionId);
            modelBuilder.Entity<Questions>().Property(q => q.PostId).HasColumnName("postid");
            modelBuilder.Entity<Questions>().Property(q => q.Title).HasColumnName("title");
            modelBuilder.Entity<Questions>().Property(q => q.AcceptedAnswerId).HasColumnName("acceptedanswerid");
            modelBuilder.Entity<Questions>().Property(q => q.ClosedDate).HasColumnName("closeddate");



            modelBuilder.Entity<Answers>().ToTable("answers");
            //modelBuilder.Entity<Answers>().HasKey(a => a.AnswerId);
            modelBuilder.Entity<Answers>().Property(a => a.AnswerId).HasColumnName("answerid");
            modelBuilder.Entity<Answers>().Property(a => a.PostId).HasColumnName("postid");
            modelBuilder.Entity<Answers>().Property(a => a.ParentId).HasColumnName("parentid");

            modelBuilder.Entity<History>().ToTable("history");
            //modelBuilder.Entity<History>().HasKey(h => h.HistoryId);
            modelBuilder.Entity<History>().Property(h => h.HistoryId).HasColumnName("id");
            modelBuilder.Entity<History>().Property(h => h.Keyword).HasColumnName("keyword");
            modelBuilder.Entity<History>().Property(h => h.SearchDate).HasColumnName("searchdate");

            modelBuilder.Entity<OwnComments>().ToTable("owncomment");
            modelBuilder.Entity<OwnComments>().Property(t => t.CommentId).HasColumnName("commentid");
            modelBuilder.Entity<OwnComments>().Property(t => t.PostId).HasColumnName("postid");
            modelBuilder.Entity<OwnComments>().Property(t => t.CommentScore).HasColumnName("commentscore");
            modelBuilder.Entity<OwnComments>().Property(t => t.CommentText).HasColumnName("commentdescription");
            modelBuilder.Entity<OwnComments>().Property(t => t.CommentCreated).HasColumnName("commentdate");

            modelBuilder.Entity<Tags>().ToTable("tags");
            modelBuilder.Entity<Tags>().Property(t => t.TagsDesc).HasColumnName("tags");
            modelBuilder.Entity<Tags>().Property(t => t.PostId).HasColumnName("postid");
            modelBuilder.Entity<Tags>().HasKey(t => new { t.PostId, t.TagsDesc });

            modelBuilder.Entity<CombinedUsers>().ToTable("combine_users");
            modelBuilder.Entity<CombinedUsers>().Property(t => t.CombineUserId).HasColumnName("Cuserid");
            modelBuilder.Entity<CombinedUsers>().Property(t => t.UserName).HasColumnName("Cuserdisplayname");
            modelBuilder.Entity<CombinedUsers>().Property(t => t.UserAge).HasColumnName("Cuserage");
            modelBuilder.Entity<CombinedUsers>().Property(t => t.UserLocation).HasColumnName("Cuserlocation");
            modelBuilder.Entity<CombinedUsers>().Property(t => t.UserCreationDate).HasColumnName("Cusercreationdate");

            base.OnModelCreating(modelBuilder);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=project_portfolio1_stackoverflow; uid=root; pwd=root");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
