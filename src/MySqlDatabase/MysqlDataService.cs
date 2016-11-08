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
        //public IList<Answers> GetAnswers()
        //{

        //    using (var db = new MysqlDataContext())
        //    {

                
        //        var answers = from s in db.Answer join r in db.Post on s.ParentId equals
        //                      r.PostsId
        //        return db.Answer;
        //    }
        //}

        //public Answers GetAnswer(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public Comments GetComment(int id)
        {
            using (var db = new MysqlDataContext())
            {
                return db.Comment.FirstOrDefault(c => c.CommentId == id);
            }
        }

        public IList<Comments> GetComments(int page, int pageSize)
        {
            using (var db = new MysqlDataContext())
            {
                return db.Comment
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .OrderBy(c => c.CommentCeated).ToList();
            }
        }

        public Posts GetPost(int id)
        {
            using (var db = new MysqlDataContext())
            {
                return db.Post.FirstOrDefault(p => p.PostsId == id);
            }
        }

        public IList<Posts> GetPosts(int page, int pageSize)
        {
            using (var db = new MysqlDataContext())
            {
                return db.Post
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .OrderBy(p => p.creationDate).ToList();
            }
        }

        public int GetTotalComments()
        {
            using (var db = new MysqlDataContext())
            {
                var count = db.Comment.Count();
                return count;
            }
        }

        public int GetTotalPosts()
        {
            using (var db = new MysqlDataContext())
            {
                var count = db.Post.Count();
                return count;
            }
        }
    }
}
