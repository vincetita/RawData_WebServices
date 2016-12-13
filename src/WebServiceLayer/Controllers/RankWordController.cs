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
            //http://localhost:5489/api/rankword?rankword=map&page=1&pageSize=10
            //"http://localhost:5489/api/rankword?keyword=map&page=1&pageSize=10",
            //"http://localhost:5489/api/rankword?rankword=map&page=1&pageSize=10",
            var result = new
            {
                Total = total,
                Prev = GetPrevUrlRankWord(Config.RankWordRoute, Url, rankword,  page, pageSize),
                Next = GetNextUrlRankWord(Config.RankWordRoute, Url, rankword, page, pageSize, total),
                data = data
            };

            return Ok(result);
        }
    }
}
