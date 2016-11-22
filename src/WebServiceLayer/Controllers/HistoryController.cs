using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlDatabase;
using DataAccessLayer;
using WebServiceLayer.JsonModels;
using AutoMapper;
using DomainModel;

namespace WebServiceLayer.Controllers
{
    [Route("api/history")]
    public class HistoryController : BaseController
    {
        public HistoryController(IDataService dataService) : base(dataService)
        {

        }

        [HttpGet(Name = Config.HistoriesRoute)]
        public IActionResult Get(int page = 0, int pageSize = Config.DefaultPageSize)
        {
            var data = DataService.GetHistories(page, pageSize)
                .Select(h => ModelFactory.Map(h, Url));

            var total = DataService.GetTotalHistory();

            var result = new
            {
                Total = total,
                Prev = GetPrevUrl(Config.HistoriesRoute, Url, page, pageSize),
                Next = GetNextUrl(Config.HistoriesRoute, Url, page, pageSize, total),
                data = data
            };

            return Ok(result);
        }

        [HttpGet("{id}", Name = Config.HistoryRoute)]
        //[Route("{id}")]           // We can use route for routing also
        public IActionResult Get(int id)
        {
            var history = DataService.GetHistory(id);
            if (history == null) return NotFound();
            return Ok(ModelFactory.Map(history, Url));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] HistoryModel model)
        {
            var history = ModelFactory.Map(model);
            DataService.AddHistory(history);
            return Ok(ModelFactory.Map(history, Url));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HistoryModel model)
        {
            var history = ModelFactory.Map(model);
            history.HistoryId = id;
            if (!DataService.UpdateHistory(history))
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!DataService.DeleteHistory(id))
            {
                return NotFound();
            }
            return Ok();
        }

        
        
    }

}
