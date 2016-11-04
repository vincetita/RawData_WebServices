using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using DataAccessLayer;

namespace MySqlDatabase
{
    public class DataService : IDataService
    {
        public IList<LinkPosts> GetLinkToPost(int limit, int offset)
        {
            return null;
            //using (var db = new MySqlDBContext())
            //{
            //    return db.LinkPost
            //        .OrderBy(c => c.PostId)
            //        .Skip(offset)
            //        .Take(limit)
            //        .ToList();
            //}
        }
    }
}
