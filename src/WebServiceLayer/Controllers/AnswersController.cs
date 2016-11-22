using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.JsonModels;

namespace WebServiceLayer.Controllers
{
    [Route("api/answers")]
    public class AnswersController : BaseController
    {
        public AnswersController(IDataService dataService) : base(dataService)
        {

        }

        [HttpGet(Name = Config.AnswersRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var data = DataService.GetAnswersList(page, pageSize)
                .Select(p => ModelFactory.Map(p, Url));

            var total = DataService.GetTotalAnswers();

            var result = new
            {
                Total = total,
                Prev = GetPrevUrl(Config.AnswersRoute, Url, page, pageSize),
                Next = GetNextUrl(Config.AnswersRoute, Url, page, pageSize, total),
                data = data
            };

            return Ok(result);
        }

       
    }
}
