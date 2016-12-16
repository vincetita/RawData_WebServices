using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceLayer.JsonModels
{
    public class ModelFactory
    {
        public static CommentsModel Map(Comments comment, IUrlHelper url)
        {
            return new CommentsModel
            {
                Url = url.Link(Config.CommentRoute, new { id = comment.CommentId }),
                CommentCeated = comment.CommentCeated,
                CommentScore = comment.CommentScore,
                CommentText = comment.CommentText,
                OwnerUserId = comment.OwnerUserId,
                PostId = comment.PostId

            };
       }

        public static OwnCommentModel Map(OwnComments owncomment, IUrlHelper url)
        {
            return new OwnCommentModel
            {
                Url = url.Link(Config.CommentRoute, new { id = owncomment.CommentId }),
                CommentCreated = owncomment.CommentCreated,
                CommentScore = owncomment.CommentScore,
                CommentText = owncomment.CommentText,
                PostId = owncomment.PostId,
                PostUrl = url.Link(Config.PostRoute, new { id = owncomment.PostId })

            };
        }

        public static OwnComments Map(OwnCommentModel model)
        {
            return new OwnComments
            {
                CommentCreated = model.CommentCreated,
                CommentScore = model.CommentScore,
                CommentText = model.CommentText,
                PostId = model.PostId

            };
        }

        public static PostsModel Map(Posts post, IUrlHelper url)
        {
            return new PostsModel
            {
                Url = url.Link(Config.PostRoute, new { id = post.PostsId }),
                PostTypeId = post.PostTypeId,
                Body = post.Body,
                creationDate = post.creationDate,
                OwnerUserId = post.OwnerUserId,
                Score = post.Score                     

            };
        }

        public static Posts Map(PostsModel model)
        {
            return new Posts
            {
                PostTypeId = model.PostTypeId,
                Body = model.Body,
                creationDate = model.creationDate,
                OwnerUserId = model.OwnerUserId,
                Score = model.Score      
                
            };
        }

        public static HistoryModel Map(History history, IUrlHelper url)
        {
            return new HistoryModel
            {
                Url = url.Link(Config.HistoryRoute, new { id = history.HistoryId }),
                Keyword = history.Keyword,
                SearchDate = history.SearchDate
            };
        }

        public static History Map(HistoryModel model)
        {
            return new History
            {
                Keyword = model.Keyword,
                SearchDate = model.SearchDate

            };
        }

        public static CombinedUsersModel Map(CombinedUsers user, IUrlHelper url)
        {
            return new CombinedUsersModel
            {
                Url = url.Link(Config.CombinedUserRoute, new { id = user.CombineUserId }),
                UserName = user.UserName,
                UserCreationDate = user.UserCreationDate,
                UserLocation = user.UserLocation,
                UserAge = user.UserAge
            };
        }

        public static CombinedUsers Map(CombinedUsersModel model)
        {
            return new CombinedUsers
            {

                UserName = model.UserName,
                UserCreationDate = model.UserCreationDate,
                UserLocation = model.UserLocation,
                UserAge = model.UserAge
            };
        }

        public static TagsModel Map(Tags tag, IUrlHelper url)
        {
            return new TagsModel
            {
                Url = url.Link(Config.TagRoute, new { id = tag.PostId }),
                TagsDesc = tag.TagsDesc
            };
        }

        public static Tags Map(TagsModel model)
        {
            return new Tags
            {
                TagsDesc = model.TagsDesc
            };
        }

        public static SearchKeywordSPModel Map(SearchKeywordStoredProc sp, IUrlHelper url)
        {
            return new SearchKeywordSPModel
            {
               Url = url.Link(Config.SearchKeywordRoute, new { id = sp.Id }),
               body = sp.body,
               ParentId = sp.ParentId,
               CommentText = sp.CommentText,
               Score = sp.Score,
               Title = sp.Title
            };
        }

        public static SearchKeywordStoredProc Map(SearchKeywordSPModel model)
        {
            return new SearchKeywordStoredProc
            {
               
                body = model.body,
                ParentId = model.ParentId,
                CommentText = model.CommentText,
                Score = model.Score,
                Title = model.Title
            };
        }

        public static RankingSPModel Map(RankingStoredProc rsp, IUrlHelper url)
        {
            return new RankingSPModel
            {
                Url = url.Link(Config.PostRoute, new { id = rsp.postsid }),
                body = rsp.body,
                Rank = rsp.Rank,
                title = rsp.title             
            };
        }

        public static RankingStoredProc Map(RankingSPModel model)
        {
            return new RankingStoredProc
            {
             body = model.body,
             Rank = model.Rank,
             title = model.title   
            };
        }

        public static QuestionModel Map(Questions questions, IUrlHelper url)
        {
            return new QuestionModel
            {   
                Url = url.Link(Config.QuestionRoute, new { id = questions.QuestionId }),
                PostId = questions.PostId,
                Title = questions.Title,
                AcceptedAnswerId = questions.AcceptedAnswerId,
                ClosedDate = questions.ClosedDate   
            };
        }

        public static Questions Map(QuestionModel model)
        {
            return new Questions
            {
                PostId = model.PostId,
                Title = model.Title,
                ClosedDate = model.ClosedDate,
                AcceptedAnswerId = model.AcceptedAnswerId               

            };
        }

        public static WordCloudModel Map(wordcloud wordCloud, IUrlHelper url)
        {
            return new WordCloudModel
            {
                text = wordCloud.word,
                weight = wordCloud.wordrank
            };
        }

        public static wordcloud Map(WordCloudModel model)
        {
            return new wordcloud
            {
                word = model.text,
                wordrank = model.weight
            };
        }
    }
}
