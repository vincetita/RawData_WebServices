
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DomainModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class LinkPostController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Route("")]
        public IEnumerable<LinkPosts> Get(int page = 0, int pagesize = 5)// when Adana is finished with the config will make ref to it
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var listOfLinkToPost = _repository.GetLinkToPost(limit, offset).select(prop => modelfactory.map(prop, Url));

            var totalLinkPosts = _repository.GetNumberOfLinkPosts();


            var lastpage = totalLinkPosts;

            var prev = page <= 0 ? null : Url.Link(Config.LinkPostsRoute, new { page = page - 1, pagesize });

            var next = page >= lastpage ? null : Url.Link(config.LinkPostsRoute, new { page = page + 1, pagesize });

            var result = new

            {
                Total = totalLinkPosts,
                Prev = prev,
                Nex = next,
                Data = listOfLinkToPost

            };
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int postid)
        {
            var linkToPostByPostid = _repository.FindLinkToPostByPostId(postId).Select(1p => modelFactory.map(1p, Url));

            return ok(linkToPostByPostid);
        }


    }
}

   
        