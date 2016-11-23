using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.Controllers
{
    [Route("api/linkposts")]
    public class LinkPostsController : BaseController
    {
        public LinkPostsController (IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.LinkPostRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize) 
        {
            var data = DataService.GetLinkToPost(page, pageSize);

            var total = DataService.GetTotalLinkPosts();

            var result = new
            {
               Total = total,
               Prev = GetPrevUrl(Config.LinkPostRoute, Url, page, pageSize),
               Next = GetNextUrl(Config.LinkPostRoute, Url, page, pageSize, total),
               Data = data

            };
            return Ok(result);
        }        
    }
}
