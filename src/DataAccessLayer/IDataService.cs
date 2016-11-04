using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataService
    {
        IList<LinkPosts> GetLinkToPost(int limit, int offset);
    }
}
