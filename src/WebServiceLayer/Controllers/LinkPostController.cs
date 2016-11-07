
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModel;
using MySqlDatabase;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceLayer.Controllers
{
    [Route("api/linkposts")]
    public class LinkPostController : BaseController
    {
        public LinkPostController(DataService dataService) : base(dataService)
        {
        }
        // GET: api/values
        [HttpGet]
        [Route("")]
        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize) // Ref to Config file
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var listOfLinkToPost = DataService.GetLinkToPost(limit, offset);

            //var listOfLinkToPost = DataService.GetLinkToPost(limit, offset).select(prop => modelfactory.map(prop, Url));

            //var totalLinkPosts = _repository.GetNumberOfLinkPosts();


            //var lastpage = totalLinkPosts;

            //var prev = page <= 0 ? null : Url.Link(Config.LinkPostsRoute, new { page = page - 1, pagesize });

            //var next = page >= lastpage ? null : Url.Link(config.LinkPostsRoute, new { page = page + 1, pagesize });

            //var result = new

            //{
            //    Total = totalLinkPosts,
            //    Prev = prev,
            //    Nex = next,
            //    Data = listOfLinkToPost

            //};
            //return Ok(result);
            return Ok(listOfLinkToPost);
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int postid)
        //{
        //    var linkToPostByPostid = _repository.FindLinkToPostByPostId(postId).Select(1p => modelFactory.map(1p, Url));

        //    return ok(linkToPostByPostid);
        //}


    }
}

   
        