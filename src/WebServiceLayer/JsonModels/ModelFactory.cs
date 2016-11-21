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

        public static PostAnswerModel Map(PostAnswer post, IUrlHelper url)
        {
            return new PostAnswerModel
            {
                Url = url.Link(Config.PostRoute, new { id = post.PostsId }),
                //PostTypeId = post.PostTypeId,
                //Body = post.Body,
                //creationDate = post.creationDate,
                //OwnerUserId = post.OwnerUserId,
                //Score = post.Score,
                Title = post.Title,
                //Answers = post.Answers

            };
        }

        public static PostAnswer Map(PostAnswerModel model, IUrlHelper url)
        {
            return new PostAnswer
            {
                //PostTypeId = model.PostTypeId,
                //Body = model.Body,
                //creationDate = model.creationDate,
                //OwnerUserId = model.OwnerUserId,
                //Score = model.Score,
                Title = model.Title//,
                //Answers = model.Answers
                
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
                Url = url.Link(Config.CombinedUsersRoute, new { id = user.CombineUserId }),
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
                Url = url.Link(Config.TagsRoute, new { id = tag.PostId }),
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
    }
}
