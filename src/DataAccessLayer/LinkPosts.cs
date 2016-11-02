using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface LinkPosts
    {
        IEnumerable<LinkedList> GetLinkPost(int limit, int offset);
        int GetNumberOfLinkPosts();
        IEnumerable<LinkPost> FindLinkPostByPostId(int postId);
    }
}
