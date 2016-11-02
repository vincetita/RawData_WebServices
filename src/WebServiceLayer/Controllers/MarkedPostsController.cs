using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class MarkedPostsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get(int page = 0, int pagesize = Config.DefaultpageSize)
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var markedPost = _repository.GetAllMarkedPosts(limit, offset).Select(mp => ModelFactory.Map(mp, Url));

            var totalMarkedPosts = _repository.GetNumberOfMarkedPosts();
            var lastpage = totalMarkedPosts / pagesize;
            var prev = page <= 0 ? null : Url.Link(config.markedPostsRouts, new { page = page - 1, pagesize });

            var next = page >= lastpage ? null : Url.Link(Config.MarkedPostsRoute, new { page = page + 1, pagesize });

            var result = new
            {

                total = totalMarkedPosts,
                Prev = prev,
                Next = next,
                Data = markedPost
            };

            return Ok(result);
        }
    }
    public string Get(int id)

    {
        if (_repository.UnMarkedPost(id) == false)

            return Notfound();
        return Ok();

    }
        }