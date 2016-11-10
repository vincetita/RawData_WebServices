using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceLayer.Controllers
{
    [Route("api/[controller]")]
    public class HistoryController : Controller
    {
        private readonly IDataService _dataService;

        public HistoryController(IDataService dataService)
        {
         _dataService = dataService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataService.GetHistories());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var history = _dataService.GetHistories(id);
            if (history == null) return NotFound();
            return Ok(history);
        } 
          
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
