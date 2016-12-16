using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.JsonModels;

namespace WebServiceLayer.Controllers
{
    [Route("api/markedposts")]
    public class MarkedPostsController : BaseController
    {
        public MarkedPostsController (IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.MarkedPostsRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize) 
        {            
            var markedPost = DataService.GetAllMarkedPosts(page, pageSize)
                .Select(p => ModelFactory.Map(p, Url)); 

            var total = DataService.GetNumberOfMarkedPosts();            

            var result = new
            {
                Total = total,
                Prev = GetPrevUrl(Config.MarkedPostsRoute, Url, page, pageSize),
                Next = GetNextUrl(Config.MarkedPostsRoute, Url, page, pageSize, total),
                Data = markedPost
            };
            return Ok(result);
        }

        ////[HttpPost]
        //public IActionResult Post(int postid)
        //{
            
        //    return Ok();
        //}

    }
}
