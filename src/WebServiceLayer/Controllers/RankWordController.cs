using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.JsonModels;

namespace WebServiceLayer.Controllers
{
    [Route("api/rankword")]
    public class RankWordController : BaseController
    {
        public RankWordController (IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.RankWordRoute)]
        public IActionResult Get(string rankword, int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var data = DataService.GetWordsbyRanking(rankword, page, pageSize)
            .Select(h => ModelFactory.Map(h, Url));

            var total = DataService.GetTotalRankWord(rankword);

            var result = new
            {
                Total = total,
                Prev = GetPrevUrl(Config.RankWordRoute, Url, page, pageSize),
                Next = GetNextUrl(Config.RankWordRoute, Url, page, pageSize, total),
                data = data
            };

            return Ok(result);
        }
    }
}
