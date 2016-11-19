using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using MySqlDatabase;
using System.Collections;

namespace MySqlDatabase
{
    public class MysqlDataService : IDataService

    {
        public bool DeleteHistory(int id)
        {
            using (var db = new MysqlDataContext())
            {
                var history = db.History.FirstOrDefault(h => h.HistoryId == id);
                if (history == null)
                {
                    return false;
                }

                db.Remove(history);
                return db.SaveChanges() > 0;

            }
        }

        public bool UpdateHistory(History history)
        {
            using (var db = new MysqlDataContext())
            {
                // Note : One way to update history
                //var dbhistory = db.History.FirstOrDefault(h => h.HistoryId == history.HistoryId);
                //if (dbhistory == null) return false;
                //dbhistory.Keyword = history.Keyword;
                //dbhistory.SearchDate = history.SearchDate;
                //db.Add(history);
                //return db.SaveChanges() > 0;

                // Another way by using attach of entity framework
                try
                {
                    db.Attach(history);                 // Attach history as part of domain model to the entity framework 
                    db.Entry(history).State = EntityState.Modified;     // Entity framework will do all the mapping and change for the stateof the object
                    return db.SaveChanges() > 0;        // To give information on number of row affected after update
                }

                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
            }

        }

        public void AddHistory(History history)
        {
            using (var db = new MysqlDataContext())
            {
                history.HistoryId = db.History.Max(h => h.HistoryId) + 1;
                db.Add(history);
                db.SaveChanges();
            }
        }

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

        public IList<History> GetHistories(int page, int pageSize)
        {
            using (var db = new MysqlDataContext())
            {
                return db.History
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .OrderBy(h => h.SearchDate).ToList();

            }
        }

        public History GetHistory(int id)
        {
            using (var db = new MysqlDataContext())
            {
                return db.History
                    .FirstOrDefault(h => h.HistoryId == id);

            }
        }

        public Posts GetPost(int id)
        {
            using (var db = new MysqlDataContext())
            {
                var result = db.Post.FirstOrDefault(p => p.PostsId == id);


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

        public int GetTotalHistory()
        {
            using (var db = new MysqlDataContext())
            {
                var count = db.History.Count();
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


        public PostAnswer GetPostAnswer(int id)
        {
            using (var db = new MysqlDataContext())
            {
                //var joinanswers = from p in db.Post
                //                  join a in db.Answer
                //                  on p.PostsId equals a.ParentId
                //                  orderby p.creationDate
                //                  select new { p.Body, p.creationDate, p.OwnerUserId };

                //var answers = db.Answer.Where(a => a.ParentId == id).Select(a => a.PostId).ToList();     // Using fluent syntax

                //var post = db.Post.Where(p => p.PostsId.Equals(answers)).Select(ps => new { ps.Body }).ToList();


                //from p in db.Post
                //       where answers.Contains(p.PostsId)
                //       select p.Body.ToList();

                var answers = from a in db.Answer
                              where a.ParentId == id
                              select a.PostId;

                var post = from p in db.Post
                            where answers.Contains(p.PostsId)
                            select p.Body.ToList();

                List<Answers> la = new List<Answers>();
                foreach (var b in la)
                {
                    la.Add(b);

                }



                var result = (from p in db.Post
                              where !db.Answer.Any(d => d.PostId == p.PostsId)
                              where p.PostsId == id
                              select new PostAnswer
                              {
                                  PostsId = p.PostsId,
                                  //Title = p.Question.Title,
                                  PostTypeId = p.PostTypeId,
                                  Body = p.Body,
                                  creationDate = p.creationDate,
                                  Score = p.Score,
                                  //Answers = la
                              }).FirstOrDefault();

                return result;


            }
        }

        public IList<OwnComments> GetOwnComments(int page, int pageSize)
        {
            using (var db = new MysqlDataContext())
            {
                return db.OwnComment
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .OrderBy(c => c.CommentCreated).ToList();
            }
        }

        public int GetTotalOwnComments()
        {
            using (var db = new MysqlDataContext())
            {
                var count = db.OwnComment.Count();
                return count;
            }
        }

        public OwnComments GetOwnCommentbyID(int id)
        {
            using (var db = new MysqlDataContext())
            {
                return db.OwnComment.FirstOrDefault(c => c.CommentId == id);
            }
        }

        public void AddOwnComment(OwnComments owncomment)
        {
            using (var db = new MysqlDataContext())
            {
                owncomment.CommentId = db.OwnComment.Max(o => o.CommentId) + 1;
                db.Add(owncomment);
                db.SaveChanges();
            }
        }

        public bool UpdateOwnComment(OwnComments own)
        {
            using (var db = new MysqlDataContext())
            {
                try
                {
                    db.Attach(own);                 
                    db.Entry(own).State = EntityState.Modified;     
                    return db.SaveChanges() > 0;        
                }

                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
            }
        }

        public bool DeleteOwnComment(int id)
        {
            using (var db = new MysqlDataContext())
            {
                var own = db.OwnComment.FirstOrDefault(o => o.CommentId == id);
                if (own == null)
                {
                    return false;
                }

                db.Remove(own);
                return db.SaveChanges() > 0;

            }
        }
    }
}

