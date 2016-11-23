using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.JsonModels;

namespace WebServiceLayer.Controllers
{
    [Route("api/questions")]
    public class QuestionsController : BaseController
    {
        public QuestionsController (IDataService dataService) : base(dataService)
        {

        }

        [HttpGet(Name = Config.QuestionsRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var data = DataService.GetQuestions(page, pageSize)
                .Select(p => ModelFactory.Map(p, Url));

            var total = DataService.GetTotalQuestions();

            var result = new
            {
                Total = total,
                Prev = GetPrevUrl(Config.QuestionsRoute, Url, page, pageSize),
                Next = GetNextUrl(Config.QuestionsRoute, Url, page, pageSize, total),
                data = data
            };

            return Ok(result);
        }

        [HttpGet("{id}", Name = Config.QuestionRoute)]
        public IActionResult Get(int id)
        {
            var question = DataService.GetQuestionbyId(id);
            if (question == null) return NotFound();
            return Ok(question);
        }
    }
}

