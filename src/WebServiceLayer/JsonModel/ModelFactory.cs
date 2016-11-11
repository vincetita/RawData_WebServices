using DomainModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.JsonModel
{
    public class ModelFactory
    {

        public static LinkPostModel Map(LinkPosts linkpost, IUrlHelper url)
        {
            // hint: use AutoMapper
            return new LinkPostModel
            {
                Url = url.Link(Config.LinkPostsRoute, new { id = linkpost.PostId }),
                LinkPostId = linkpost.LinkPostId
            };
        }

        public static LinkPosts Map(LinkPostModel model)
        {
            // hint: use AutoMapper
            return new LinkPosts
            {
                LinkPostId = model.LinkPostId,
            };
        }

        //markpost


        public static MarkedPostsModel Map(MarkedPosts markedposts, IUrlHelper url)
        {

            return new MarkedPostsModel
            {
                Url = url.Link(Config.MarkedPostsRoute, new { id = markedposts.PostId }),
                LinkPostId = markedposts.markedId
            };
        }

        
        public static MarkedPosts Map(MarkedPostsModel model)
        {

            return new MarkedPosts
            {
                PostId = model.LinkPostId
            };
        }
    }
}