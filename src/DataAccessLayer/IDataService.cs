using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataService
    {
        // Comments
        IList<Comments> GetComments(int page, int pageSize);
        Comments GetComment(int id);
        int GetTotalComments();
       
        // Posts
        IList<Posts> GetPosts(int page, int pageSize);
        Posts GetPost(int id);
        int GetTotalPosts();

        // History
        IList<History> GetHistories(int page, int pageSize);
        History GetHistory(int id);
        int GetTotalHistory();
        void AddHistory(History history);
        bool UpdateHistory(History history);        
        bool DeleteHistory(int id);
        

        // Own Comments (For CRUD on our ownComments table)
        IList<OwnComments> GetOwnComments(int page, int pageSize);
        int GetTotalOwnComments();
        OwnComments GetOwnCommentbyID(int id);
        void AddOwnComment(OwnComments owncomment);
        bool UpdateOwnComment(OwnComments own);
        bool DeleteOwnComment(int id);
        
        // Combine Users       
        IList<CombinedUsers> GetCombinedUsers(int page, int pagesize);
        CombinedUsers GetCombinedUserById(int id);
        int GetNumberOfUsers();

        // Tags

        IList<Tags> GetTags(int page, int pagesize);
        IList<Tags> GetTagsById(int id);
        int GetNumberOfTags();

        // Stored Procedure SearchKeyword
        IList<SearchKeywordStoredProc> GetPostsbySearchKeyword(string search, int page, int pageSize);
        int GetTotalSearchKeywordResult(string search);

        // Stored Procedure RankWord
        IList<RankingStoredProc> GetWordsbyRanking(string search, int page, int pageSize);
        int GetTotalRankWord(string rankword);

        // Answers
        IList<Posts> GetAnswersList(int page, int pageSize);
        int GetTotalAnswers();
       
        // Returning anwers list for specific post
        IList<Posts> GetAnswersForSpecificPost(int id);

        // Questions
        IList<Questions> GetQuestions(int page, int pageSize);
        int GetTotalQuestions();
        Questions GetQuestionbyId(int id);

        // LinkPosts
        IList<LinkPosts> GetLinkToPost(int page, int pageSize);
        int GetTotalLinkPosts();

        // MarkPosts
        IList<Posts> GetAllMarkedPosts(int page, int pageSize);
        int GetNumberOfMarkedPosts();
        void AddMarkPost(int postid);

        // WordCloud
        IList<wordcloud> Getwordcloud(string word, int page, int pageSize);
        int GetWordCloud(string word);

    }
}
