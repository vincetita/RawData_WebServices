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
                PostId = owncomment.PostId

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

        public static PostAnswerModel Map(PostAnswer post, IUrlHelper url)
        {
            return new PostAnswerModel
            {
                Url = url.Link(Config.AnswersRoute, new { id = post.PostsId}),
                //Title = post.Question.Title,               
                //UserName = post.UserName
                //Answers = post.Answers
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
    }
}
