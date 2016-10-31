using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface IDataService
    {
        IList<Comments> GetComments();
    }
}
