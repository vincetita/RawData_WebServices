using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public interface IDataService
    {
        IList<Tags> GetTagses(int page, int pagesize);
        Tags GetTagsById(int id);
        int GetNumberOfTags();

        IList<CombinedUsers> GetCombinedUserses(int page, int pagesize);
        CombinedUsers GetCombinedUserById(int id);
        int GetNumberOfUsers();

    }


    //public interface IDataService
    //{
    //    IList<Comments> GetComments();
    //    IList<Posts> GetPosts();
    //    IList<Answers> GetAnswers();
    //}
}
