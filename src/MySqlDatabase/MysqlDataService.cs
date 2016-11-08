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
        public IList<Answers> GetAnswers()
        {
            throw new NotImplementedException();
        }

        public IList<Comments> GetComments()
        {
            using (var db = new MysqlDataContext())
            {
                return db.Comment.OrderBy(c => c.CommentCeated).ToList();
            }
        }

        public IList<Posts> GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}
