using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlDatabase;

namespace WebServiceLayer.Controllers
{
    [Route("api/linkposts")]
    public class MarkedPostsController : BaseController
    {
        public MarkedPostsController(DataService dataService) : base(dataService)
        {
        }

public IHttpActionResult Get(int page = 0, int pagesize =5  //Config.DefaultPageSize)// Ref will be made when Adnan is finished with Config
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var markedPost = DataService.GetAllMakedPosts(limit, offset).Select(mp => ModelFactory.Map(mp, Url));

            var totalMarkedPosts = DataService.GetNumberOfMarkedPosts();
            var lastpage = totalMarkedPosts / pagesize;
            var prev = page <= 0 ? null : Url.Link(Config.MarkedPostsRoute, new { page = page - 1, pagesize });
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

        /* Unmark Post*/
        public IHttpActionResult Put(int id)
        {
            if (DataService.UnMarkPost(id) == false)
                return NotFound();
            return Ok();
        }
    }
}



