using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using MySqlDatabase;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data;

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
                
                try
                {
                    db.Attach(history);                 
                    db.Entry(history).State = EntityState.Modified;     
                    return db.SaveChanges() > 0;        
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

        public IList<Posts> GetPosts(int page, int pageSize)
        {
            using (var db = new MysqlDataContext())
            {
                var post = db.Post
                         .Where(b => b.PostTypeId == 1)
                         .Skip(page * pageSize)
                         .Take(pageSize)
                         .OrderBy(p => p.creationDate)
                         .ToList();

                return post;
            }
        }

        public Posts GetPost(int id)
        {
            using (var db = new MysqlDataContext())
            {
                var result = db.Post.FirstOrDefault(p => p.PostsId == id);
                return result;
            }
        }

        public int GetTotalPosts()
        {
            using (var db = new MysqlDataContext())
            {
                var count = db.Post.Where(p => p.PostTypeId == 1).
                    Count();
                return count;
            }
        }

        public IList<Posts> GetAnswersList(int page, int pageSize)
        {
            
                using (var db = new MysqlDataContext())
                {
                var answers = db.Post
                     .Where(b => b.PostTypeId == 2)
                     .Skip(page * pageSize)
                     .Take(pageSize)
                     .OrderBy(p => p.creationDate)
                     .ToList();

                return answers;
            }
        }

        public int GetTotalAnswers()
        {
            using (var db = new MysqlDataContext())
            {
                var count = db.Post.Where(p => p.PostTypeId == 2).
                    Count();
                return count;
            }
        }

        
        public IList<Posts> GetAnswersForSpecificPost(int id)
        {
            using (var db = new MysqlDataContext())
            {
                var answerid = from a in db.Answer
                              where a.ParentId == id
                              select a.PostId;

                var post = (from p in db.Post
                            where answerid.Contains(p.PostsId)
                            select new Posts{
                                PostsId = p.PostsId,
                                Body = p.Body,
                                creationDate = p.creationDate,                                
                                Score = p.Score,
                                PostTypeId = p.PostTypeId,
                                OwnerUserId = p.OwnerUserId
                                }).ToList();                
                return post;
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

        public IList<Tags> GetTags(int page, int pagesize)
        {
            using (var db = new MysqlDataContext())
            {
                return db.Tags
                    .OrderBy(c => c.PostId)
                    .Skip(page * pagesize)
                    .Take(pagesize)
                    .ToList();
            }
        }

        public IList<Tags> GetTagsById(int id)
        {
            using (var db = new MysqlDataContext())
            {

                return db.Tags.Where(c => c.PostId == id).ToList();
                
            }
        }

        public int GetNumberOfTags()
        {
            using (var db = new MysqlDataContext())
            {
                return db.Tags.Count();
            }
        }

        public IList<CombinedUsers> GetCombinedUsers(int page, int pagesize)
        {
            using (var db = new MysqlDataContext())
            {
                return db.CombineUsers
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

                return db.CombineUsers.FirstOrDefault(c => c.CombineUserId == id);
            }
        }


        public int GetNumberOfUsers()
        {
            using (var db = new MysqlDataContext())
            {
                return db.CombineUsers.Count();
            }
        }

        public IList<SearchKeywordStoredProc> GetPostsbySearchKeyword(string searchword, int page, int pageSize)
        {
            
            using (var db = new MysqlDataContext())
            {
                var cmds = db.SearchKeyordStoredProc.FromSql("call search_keyword({0})", searchword);
                var result = new List<SearchKeywordStoredProc>();

                foreach (var item in cmds)
                {
                    result.Add(item);
                }
                return result;
                                          
            }            
        }

        public int GetTotalSearchKeywordResult(string search)
        {
            using (var db = new MysqlDataContext())
            {
                var cmds = db.SearchKeyordStoredProc.FromSql("call search_keyword({0})", search);
                //var list = new List<SearchKeywordStoredProc>();
                var result = cmds.Count();
                return result;
            }
        }

        public IList<RankingStoredProc> GetWordsbyRanking(string rankword, int page, int pageSize)
        {
            using (var db = new MysqlDataContext())
            {
                var cmds = db.RankStoredProc.FromSql("call ranking({0})", rankword)
                .Skip(page * pageSize)
                    .Take(pageSize);
                var result = new List<RankingStoredProc>();

                foreach (var item in cmds)
                {
                    result.Add(item);
                }
                return result;

            }
        }

        public int GetTotalRankWord(string rankword)
        {
            using (var db = new MysqlDataContext())
            {
                var cmds = db.RankStoredProc.FromSql("call ranking({0})", rankword);
                //var list = new List<RankingStoredProc>();                
                var result = cmds.Count();
                return result;
            }
        }

        public IList<Questions> GetQuestions(int page, int pageSize)
        {
            using (var db = new MysqlDataContext())
            {
                var questions = db.Question
                         .Skip(page * pageSize)
                         .Take(pageSize)
                         .ToList();
                return questions;
            }
        }

        public int GetTotalQuestions()
        {
            using (var db = new MysqlDataContext())
            {
                return db.Question.Count();
            }
        }

        public Questions GetQuestionbyId(int id)
        {
            using (var db = new MysqlDataContext())
            {
                return db.Question.FirstOrDefault(q => q.QuestionId == id);                
            }
        }

        public IList<LinkPosts> GetLinkToPost(int page, int pageSize)
        {
            using (var db = new MysqlDataContext())
            {
                return db.LinkPost
                    .OrderBy(c => c.PostId)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }

        public int GetTotalLinkPosts()
        {
            using (var db = new MysqlDataContext())
            {
                return db.LinkPost.Count();
            }
        }

        public IList<Posts> GetAllMarkedPosts(int page, int pageSize)
        {
            using (var db = new MysqlDataContext())
            {
                var markedid = from m in db.MarkPost                               
                               select m.PostId;

                var post = (from p in db.Post
                            where markedid.Contains(p.PostsId)
                            select new Posts
                            {
                                PostsId = p.PostsId,
                                Body = p.Body,
                                creationDate = p.creationDate,
                                Score = p.Score,
                                PostTypeId = p.PostTypeId,
                                OwnerUserId = p.OwnerUserId
                            }).ToList();
                
                var result = post
                            .OrderBy(m => m.creationDate)
                            .Skip(page * pageSize)
                            .Take(pageSize)
                            .ToList();

                return result;
            }
        }

        public void AddMarkPost(int postid)
        {
            using (var db = new MysqlDataContext())
            {
                //var cmds = db.MarkedPostStoredProc.FromSql("call insert_markpost({0})", postid);
                         
                               
            }
        }

        public int GetNumberOfMarkedPosts()
        {            
                using (var db = new MysqlDataContext())
                {
                    return db.MarkPost.Count();
                }
            
        }

        public IList<wordcloud> Getwordcloud(string word, int page, int pageSize)
        {
            using (var db = new MysqlDataContext())
            {
                var cmds = db.WrodCloudProc.FromSql("call wordranking({0})", word);
                var result = new List<wordcloud>();

                foreach (var item in cmds)
                {
                    result.Add(item);
                }
                return result;

            }
        }

        public int GetWordCloud(string word)
        {
            using (var db = new MysqlDataContext())
            {
                var cmds = db.WrodCloudProc.FromSql("call wordranking({0})", word).Count();         
                //var result = cmds.Count();
                return cmds;
            }
        }

        
    }
}



