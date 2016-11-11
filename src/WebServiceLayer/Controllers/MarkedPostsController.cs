using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlDatabase;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceLayer.Controllers
{
    [Route("api/markedposts")]
    public class MarkedPostsController : BaseController
    {
        public MarkedPostsController(DataService dataService) : base(dataService)
        {
        }

        [HttpGet]
        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize) // Ref to Config file
        {
            int limit = pagesize;
            int offset = page * pagesize;
            var markedPost = DataService.GetAllMakedPosts(limit, offset);

            var totalMarkedPosts = DataService.GetNumberOfMarkedPosts();
            var lastpage = totalMarkedPosts / pagesize;
            //var prev = page <= 0 ? null : Url.Link(Config.MarkedPostsRoute, new { page = page - 1, pagesize });
            //var next = page >= lastpage ? null : Url.Link(Config.MarkedPostsRoute, new { page = page + 1, pagesize });

            var result = new
            {
                total = totalMarkedPosts,
                //Prev = prev,
                //Next = next,
                Data = markedPost
            };
            return Ok(result);
        }

        /* Unmark Post*/
        //public IActionResult Put(int id)
        //{
        //    if (DataService.UnMarkPost(id) == false)
        //        return NotFound();
        //    return Ok();
        //}
    }
}
