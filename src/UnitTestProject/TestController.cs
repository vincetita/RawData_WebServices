using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using DataAccessLayer;
using WebServiceLayer.Controllers;
using WebServiceLayer.JsonModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using DomainModel;
using System.Reflection;

namespace UnitTestProject
{
    public class TestController
    {        
        [Fact]
        public void GetPostsListTest()
        {
            var mock = new Mock<IDataService>();
            mock.Setup(c => c.GetComment(It.IsAny<int>())).Returns(new Comments
            {
                CommentId = 32,
                PostId = 1,
                CommentText = "Unit Testing for the Posts controller with mock data",
                CommentScore = 3,
                OwnerUserId = 46,
                CommentCeated = new DateTime(2016, 11, 22, 9, 6, 13)
            });

            var mocking = new Mock<IUrlHelper>();
            mocking.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns((string url, object idObject) =>
                {
                    Type typeidObject = idObject.GetType();
                    int valueObject =
                        (int)typeidObject.GetProperty("id").GetValue(idObject, null);

                    return "http//localhost/api/comments" + valueObject;
                });

            var controller = new CommentsController(mock.Object);
            controller.Url = mocking.Object;

            IActionResult actionResult = controller.Get(1);
            OkObjectResult OkObjectResult = actionResult as OkObjectResult;
            CommentsModel commentModel = (CommentsModel)OkObjectResult.Value;

            Assert.Equal("http//localhost/api/comments/1", commentModel.Url);
            Assert.Equal("Unit Testing for the Posts controller with mock data", commentModel.CommentText);
            Assert.Equal(3, commentModel.CommentScore);
            Assert.Equal(46, commentModel.OwnerUserId);
            Assert.Equal(1, commentModel.PostId);
            Assert.Equal(new DateTime(2016, 11, 22, 9, 6, 13), commentModel.CommentCeated);
        }
    }
}

