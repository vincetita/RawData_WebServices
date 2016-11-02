using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface LinkedPost     
   {
        IEnumerable<post> GetAllMarkedPosts(int limit, int offset);
        int GetNumberOfMarkedPosts();
        bool UnMarkPost(int id);
    }
}
