using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer
{
    public class Config
    {
        public const int DefaultPageSize = 10;
        
        public const string CommentRoute = "CommentRoute";
        public const string CommentsRoute = "CommentsRoute";

        public const string OwnCommentRoute = "OwnCommentRoute";
        public const string OwnCommentsRoute = "OwnCommentsRoute";

        public const string PostRoute = "PostRoute";
        public const string PostsRoute = "PostsRoute";

        public const string HistoryRoute = "HistoryRoute";
        public const string HistoriesRoute = "HistoriesRoute";

        public const string AnswersRoute = "AnswersRoute";

        public const string CombinedUsersRoute = "CombinedUsersRoute";
        public const string CombinedUserRoute = "CombinedUserRoute";

        public const string TagsRoute = "TagsRoute";
        public const string TagRoute = "TagRoute";

        public const string SearchKeywordRoute = "SearchKeywordRoute";

        public const string RankWordRoute = "RankWordRoute";

        public const string QuestionsRoute = "QuestionsRoute";
        public const string QuestionRoute = "QuestionRoute";

        public const string LinkPostRoute = "LinkPostRoute";

        public const string MarkedPostsRoute = "MarkedPostsRoute";

        public const string WordCloudRoute = "WordcloudRoute";
    }
}
