using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using MySqlDatabase;

namespace MySqlDatabase
{
    public class MysqlDataService : IDataService

    {
        public DbSet<Answers> Anwser { get; set; }
        public IList<Answers> GetAnswers()
        {
            throw new NotImplementedException();
        }
        //
        public IList<Questions> GetQuestion()
        {
            using (var db = new MysqlDataContext())
            {
                return db.Question.ToList();
            }
        }

        public Questions GetQuestion(int id)
        {
            using (var db = new MysqlDataContext())
            {
                return db.Question.FirstOrDefault();
            }
        }

        public IList<History> GetHistories()
        {
            using (var db = new MysqlDataContext())
            {
                return db.Histories.ToList();
            }
        }

        public History GetHistories(int id)
        {
            using (var db = new MysqlDataContext())
            {
                return db.Histories.FirstOrDefault();
            }
        }

        public IList<LinkPosts> GetLinkToPost(int limit, int offset)
        {
            throw new NotImplementedException();
        }



        
        

        //public  IList<Comments> GetComments()
        //{
        //    using (var db = new MysqlDataContext())
        //    {
        //        return db.Comment.OrderBy(c => c.CommentCeated).ToList();
        //    }
        //}


        public IList<Comments> GetComments()
        {
            throw new NotImplementedException();
        }

        public IList<Posts> GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}
