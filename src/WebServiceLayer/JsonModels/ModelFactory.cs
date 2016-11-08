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
                Url = url.Link(Config.CommentsRoute, new { id = comment.CommentId }),
                CommentCeated = comment.CommentCeated,
                CommentScore = comment.CommentScore,
                CommentText = comment.CommentText,
                OwnerUserId = comment.OwnerUserId,
                PostId = comment.PostId

            };
        }

        //public static PostsModel Map(Posts post, IUrlHelper url)
        //{
        //    return new PostsModel
        //    {
        //        Url = url.link(Config.PostsRoute, new { id = post.PostsId}),
        //        Pos


        //    }
        //}
    }
}
