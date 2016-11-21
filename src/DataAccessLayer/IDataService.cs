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
        int GetTotalComments();
        //IList<PostAnswer> GetPosts(int page, int pageSize);

        IList<PostAnswer> GetPosts(int page, int pageSize);
        PostAnswer GetPost(int id);
        int GetTotalPosts();
        IList<History> GetHistories(int page, int pageSize);
        History GetHistory(int id);
        int GetTotalHistory();
        void AddHistory(History history);
        bool UpdateHistory(History history);
        bool DeleteHistory(int id);



        //PostAnswer GetPostAnswer(int id);

        IList<OwnComments> GetOwnComments(int page, int pageSize);
        int GetTotalOwnComments();
        OwnComments GetOwnCommentbyID(int id);
        void AddOwnComment(OwnComments owncomment);
        bool UpdateOwnComment(OwnComments own);
        bool DeleteOwnComment(int id);
               
        IList<CombinedUsers> GetCombinedUsers(int page, int pagesize);
        CombinedUsers GetCombinedUserById(int id);
        int GetNumberOfUsers();
        IList<Tags> GetTags(int page, int pagesize);
        Tags GetTagsById(int id);

        int GetNumberOfTags();

        IList<SearchKeywordStoredProc> GetPostsbySearchKeyword(string search);
        //int GetTotalSearchPostsResult(string search);


        //IList<Answers> GetAnswers(int page, int pageSize);
        //Answers GetAnswer(int id);
    }
}
