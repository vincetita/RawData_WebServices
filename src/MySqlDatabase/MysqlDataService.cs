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

        public IList<Tags> GetTagses(int page, int pagesize)
        {
            using (var db = new MysqlDataContext())
            {
                return db.Tagses
                    .OrderBy(c => c.PostId)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public Tags GetTagsById(int id)
        {
            using (var db = new MysqlDataContext())
            {
                return db.Tagses.FirstOrDefault(c => c.PostId == id);

            }
        }

        public int GetNumberOfTags()
        {
            using (var db = new MysqlDataContext())
            {
                return db.Tagses.Count();
            }
        }

        public IList<CombinedUsers> GetCombinedUserses(int page, int pagesize)
        {
            using (var db = new MysqlDataContext())
            {
                return db.CombinedUserses
                    .OrderBy(c => c.CombineUserId)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public CombinedUsers GetCombinedUserById(int id)
        {
            using (var db = new MysqlDataContext())
            {

                return db.CombinedUserses.FirstOrDefault(c => c.CombineUserId == id);
            }
        }


        public int GetNumberOfUsers()
        {
            using (var db = new MysqlDataContext())
            {
                return db.CombinedUserses.Count();
            }
        }
    }


    //public class MysqlDataService : IDataService

    //{
    //    public IList<Answers> GetAnswers()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IList<Comments> GetComments()
    //    {
    //        using (var db = new MysqlDataContext())
    //        {
    //            return db.Comment.OrderBy(c => c.CommentCeated).ToList();
    //        }
    //    }

    //    public IList<Posts> GetPosts()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
