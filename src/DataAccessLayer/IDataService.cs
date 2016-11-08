using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataService
    {
        IList<Comments> GetComments(int page, int pageSize);
        Comments GetComment(int id);
        IList<Posts> GetPosts(int page, int pageSize);
        Posts GetPost(int id);

        int GetTotalComments();

        int GetTotalPosts();
        //IList<Answers> GetAnswers();
        //Answers GetAnswer(int id);
    }
}
