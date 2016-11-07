using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public interface IDataService 
    {
        IList<Comments> GetComments();
        IList<Posts> GetPosts();
        IList<Answers> GetAnswers();
        IList<Tags> GetTags();



    }
}
