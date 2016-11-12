using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebServiceLayer.JsonModels;


namespace WebServiceLayer.JsonModels
{
    public class ModelFactory
    {
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

    }
}
