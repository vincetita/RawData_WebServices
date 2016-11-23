using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.JsonModels;

namespace WebServiceLayer.Controllers
{
    [Route("api/searchkeyword")]
    public class SearchKeywordController : BaseController
    {
        public SearchKeywordController (IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.SearchKeywordRoute)]
        public IActionResult Get(string search, int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var data = DataService.GetPostsbySearchKeyword(search, page, pageSize)
            .Select(h => ModelFactory.Map(h, Url));

            var total = DataService.GetTotalSearchKeywordResult(search);

            var result = new
            {
                Total = total,
                Prev = GetPrevUrl(Config.SearchKeywordRoute, Url, page, pageSize),
                Next = GetNextUrl(Config.SearchKeywordRoute, Url, page, pageSize, total),
                data = data
            };

            return Ok(result);
        }
    }
}
