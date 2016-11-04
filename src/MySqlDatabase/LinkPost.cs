using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlDatabase
{
    public class LinkPost
    {
                 LinkePost

        public IEnumerable<LinkPost> GetLinkToPost(int limit, int offset)
        {
            using (var db = new StackOverflowContext())
            {
                return db.LinkPosts
                    .OrderBy(lp => lp.PostId)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetNumberOfLinkPosts()
        {
            using (var db = new StackOverflowContext())
            {
                return db.LinkPosts.Count();
            }
        }

        public IEnumerable<LinkPost> FindLinkToPostByPostId(int postId)
        {
            using (var db = new StackOverflowContext())
            {
                return db.LinkPosts
                    .Where(lp => lp.PostId == postId)
                    .ToList();
            }
        }

    }
}
